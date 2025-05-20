using Razorpay.Api;
using Razorpay;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.User
{
    public partial class Cart : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FullName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }


            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                    return;
                }
                LoadCart();
            }
        }

        private void LoadCart()
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            //int userId = 1;

            int userId = Convert.ToInt32(Session["UserID"]);

            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("GetCartDetailsByUserID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DatalistCourse.DataSource = dt;
                DatalistCourse.DataBind();

                GridViewCart.DataSource = dt;
                GridViewCart.DataBind();

                // Calculate Total Price
                decimal totalPrice = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Price"] != DBNull.Value)
                        totalPrice += Convert.ToDecimal(row["Price"]);
                }

                // Set the Total Price label
                lblTotalPrice.Text = totalPrice.ToString("0.00");

            }
        }

        protected void btnRemove_Command(object sender, CommandEventArgs e)
        {
            int cartId = Convert.ToInt32(e.CommandArgument);
            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("RemoveFromCart", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartID", cartId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            LoadCart();
        }


        protected void btnPay_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            //int userId = 1;
            int userId = Convert.ToInt32(Session["UserID"]);

            string cnf = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();


            string s = $"exec myCourse'{userId}'";
            SqlCommand cmd = new SqlCommand(s, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                string t = $"exec deleteCart '{userId}' ";
                SqlCommand cmd2 = new SqlCommand(t, conn);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                Response.Write("<script>alert('Your Cart is Empty')</script>");
            }


            string keyId = "rzp_test_Kl7588Yie2yJTV";
            string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";

            RazorpayClient razorpayClient = new RazorpayClient(keyId, keySecret);

            int amount = int.Parse(lblTotalPrice.Text);


            // Create an order
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amount * 100); // Amount should be in paisa (multiply by 100 for rupees)
            options.Add("currency", "INR");
            options.Add("receipt", "order_receipt_123");
            options.Add("payment_capture", 1); // Auto capture payment

            Razorpay.Api.Order order = razorpayClient.Order.Create(options);

            string orderId = order["id"].ToString();

            // Generate checkout form and redirect user to Razorpay payment page
            string razorpayScript = $@"
            var options = {{
                'key': '{keyId}',
                'amount': {amount * 100},
                'currency': 'INR',
                'name': 'EduHub E-Learning',
                'description': 'Checkout Payment',
                'order_id': '{orderId}',
                'handler': function(response) {{
                    // Handle successful payment response
                    alert('Payment successful. Payment ID: ' + response.razorpay_payment_id);
                    window.location.href = '/User/mycourses.aspx';
                }},
                'prefill': {{
                    'name': 'Krish Kheloji',
                    'email': 'khelojikrish@gmail.com',
                    'contact': '7208921898'
                }},
                'theme': {{
                    'color': '#F37254'
                }}
            }};
            var rzp1 = new Razorpay(options);
            rzp1.open();";

            // Register the script on the page

            ClientScript.RegisterStartupScript(this.GetType(), "razorpayScript", razorpayScript, true);

            //Response.Redirect("MyCourses.aspx");




            if (Session["DiscountCaptcha"] != null)
            {
                string usedCaptcha = Session["DiscountCaptcha"].ToString();

                SqlCommand delCmd = new SqlCommand("DELETE FROM SpinOffers WHERE Captcha = @Captcha", conn);
                delCmd.Parameters.AddWithValue("@Captcha", usedCaptcha);
                delCmd.ExecuteNonQuery();

                Session["DiscountCaptcha"] = null;
            }



        }















        protected void btnApplyOffer_Click(object sender, EventArgs e)
        {
            string enteredCaptcha = txtOfferCaptcha.Text.Trim();
            if (string.IsNullOrEmpty(enteredCaptcha))
            {
                lblDiscountMsg.Text = "Enter captcha first.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DiscountPercentage, Email FROM SpinOffers WHERE Captcha = @Captcha", conn);
                cmd.Parameters.AddWithValue("@Captcha", enteredCaptcha);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int discount = Convert.ToInt32(reader["DiscountPercentage"]);
                    string email = reader["Email"].ToString();

                    decimal totalPrice = Convert.ToDecimal(lblTotalPrice.Text);
                    decimal newPrice = totalPrice - (totalPrice * discount / 100);
                    lblTotalPrice.Text = newPrice.ToString("0.00");

                    Session["DiscountCaptcha"] = enteredCaptcha; // Store for deletion after payment

                    lblDiscountMsg.Text = $"Offer applied: {discount}% off!";
                }
                else
                {
                    lblDiscountMsg.Text = "Invalid or used captcha.";
                }
            }
        }















    }
}