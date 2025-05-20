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

            if (!IsPostBack)
            {
                conn.Open();
                LoadSubscriptionPlans();
            }
        }

        private void LoadSubscriptionPlans()
        {
            string query = "fetchUserSubscriptionPlan";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataList1.DataSource = reader;
            DataList1.DataBind();
            reader.Close();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "BuyNow")
            {
                string[] args = e.CommandArgument.ToString().Split('|');
                string masterCourse = args[0];
                string subscriptionPlanIDStr = args[1]; 
                string planName = args[2];
                string price = args[3];
                string validity = args[4];

                int userId = Convert.ToInt32(Session["UserID"].ToString());
                int subscriptionPlanId = Convert.ToInt32(subscriptionPlanIDStr); 




                string query = @"
INSERT INTO MyCourses (UserID, SubCourseID, AddedAt, SubCourseName, Picture, Duration)
SELECT
    @UserID,
    sc.SubCourseID,
    GETDATE(),
    sc.SubCourseName,
    sc.Picture,
    sc.Duration
FROM SubscriptionPlanSubCourses spsc
JOIN SubCourses sc ON spsc.SubCourseID = sc.SubCourseID
WHERE spsc.SubscriptionPlanID = @PlanID
AND NOT EXISTS (
    SELECT 1
    FROM MyCourses mc
    WHERE mc.UserID = @UserID AND mc.SubCourseID = sc.SubCourseID
);";

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@PlanID", subscriptionPlanId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                    }
                }









                string keyId = "rzp_test_Kl7588Yie2yJTV";
                string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";

                RazorpayClient razorpayClient = new RazorpayClient(keyId, keySecret);

                double amount = double.Parse(price);


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





                //Response.Redirect($"Buy.aspx?course={masterCourse}&subscriptionplanid={subscriptionPlanID}&plan={planName}&price={price}&validity={validity}");
            }
        }

        //public string GetPlanClass(string planName)
        //{
        //    switch (planName.ToLower())
        //    {
        //        case "gold":
        //            return "gold";
        //        case "silver":
        //            return "silver";
        //        case "bronze":
        //            return "bronze";
        //        default:
        //            return "silver";
        //    }
        //}


        protected string GetPlanClass(string planName)
        {
            switch (planName.ToLower())
            {
                case "gold":
                    return "gold";
                case "silver":
                    return "silver";
                case "bronze":
                    return "bronze";
                default:
                    return "bg-secondary";
            }
        }



    }
}
