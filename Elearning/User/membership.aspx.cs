using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Elearning.User
{
    public partial class membership : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                LoadPlans();
            }
        }

        private void LoadPlans()
        {
            string query = " EXEC FETCHSubscriptionPlan";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            Repeater1.DataSource = rdr;
            Repeater1.DataBind();
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            double planId = double.Parse(btn.CommandArgument);
            //Response.Redirect("Cart.aspx?planId=" + planId);


            string keyId = "rzp_test_Kl7588Yie2yJTV";
            string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";

            RazorpayClient razorpayClient = new RazorpayClient(keyId, keySecret);

            double amount = planId;


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




        }




    }
}
