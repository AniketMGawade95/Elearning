using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Accounts
{
    public partial class startingmainpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();

                if (Session["MessageSent"] != null && (bool)Session["MessageSent"])
                {
                    litMessage.Text = "<div class='alert alert-success'>Message sent successfully!</div>";
                    Session.Remove("MessageSent");
                }

                BindReviews();

                pnlCaptcha.Visible = false;

                //imgSpinWheel.Visible = false;




            }
        }




        private void BindReviews()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                string query = @"SELECT 
                                r.RatingID,
                                r.UserID,
                                u.Name AS UserName,
                                u.ProfilePic,
                                r.SubCourseID,
                                r.Rating,
                                r.Review AS ReviewText,
                                r.CreatedDate
                             FROM Ratings r
                             INNER JOIN Users u ON r.UserID = u.UserID
                             ORDER BY r.CreatedDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptReviews.DataSource = dt;
                rptReviews.DataBind();
            }
        }

        public string GetStars(int rating)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rating; i++)
            {
                sb.Append("★");
            }
            for (int i = rating; i < 5; i++)
            {
                sb.Append("☆");
            }
            return sb.ToString();
        }




        private void LoadCourses()
        {
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT SubCourseID, SubCourseName, Price, Picture, Rating FROM SubCourses";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rptCourses.DataSource = rdr;
                rptCourses.DataBind();
            }
        }

        protected void rptCourses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("coursedetails.aspx?id=" + id);
            }
        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(txtEmail.Text.Trim());
                    mail.To.Add("aniketmgawade2019@gmail.com");
                    mail.Subject = txtSubject.Text.Trim();
                    mail.Body = $"<strong>Name:</strong> {txtName.Text}<br/>" +
                                $"<strong>Email:</strong> {txtEmail.Text}<br/><br/>" +
                                $"<strong>Message:</strong><br/>{txtMessage.Text}";
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Credentials = new NetworkCredential("aniketmgawade2019@gmail.com", "dpdivxmqwngsrgvk");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    smtp.Send(mail);

                    // Store a flag in session to show success message after redirect
                    Session["MessageSent"] = true;

                    // Redirect to the same page to prevent resubmission
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                litMessage.Text = $"<div class='alert alert-danger'>Error: {ex.Message}</div>";
            }
        }







        protected void btnSpin_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                lblResult.Text = "Please enter your email.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Check if email already exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM SpinOffers WHERE Email=@Email", conn);
                checkCmd.Parameters.AddWithValue("@Email", email);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    lblResult.Text = "You have already used the spin.";
                    pnlCaptcha.Visible = false;
                    //imgSpinWheel.Visible = false;
                    return;
                }

                // Show spin wheel gif
                //imgSpinWheel.Visible = true;

                // Generate random discount and captcha
                int[] discounts = { 5, 10, 15, 20 };
                Random rand = new Random();
                int discount = discounts[rand.Next(discounts.Length)];
                string captchaCode = GenerateCaptcha();

                // Store in DB
                SqlCommand insertCmd = new SqlCommand("INSERT INTO SpinOffers (Email, Captcha, DiscountPercentage) VALUES (@Email, @Captcha, @Discount)", conn);
                insertCmd.Parameters.AddWithValue("@Email", email);
                insertCmd.Parameters.AddWithValue("@Captcha", captchaCode);
                insertCmd.Parameters.AddWithValue("@Discount", discount);
                insertCmd.ExecuteNonQuery();

                // Store captcha in session for reference (optional, if you want to use it later)
                Session["Captcha"] = captchaCode;
                Session["Email"] = email;

                // Display result
                lblCaptcha.Text = $"Captcha: {captchaCode}";
                lblResult.Text = $"🎉 Congratulations! You've won a {discount}% discount! Use this captcha at checkout.";
                pnlCaptcha.Visible = true;  // Show captcha panel
            }
        }


        private string GenerateCaptcha()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }


        














    }
}