using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Accounts
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(connection);
            con.Open();



        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                sendmail(email);
            }

            txtEmail.Text = "";
           
        }


        public void sendmail(string em)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = "SELECT Password FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", em);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string pass = rdr["Password"].ToString();

                        MailMessage mail2 = new MailMessage();
                        mail2.From = new MailAddress("aniketmgawade2019@gmail.com");
                        mail2.To.Add(em);
                        mail2.Subject = "Elearning Password Recovery";
                        mail2.Body = $"Your Password is: {pass}";

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.Credentials = new NetworkCredential("aniketmgawade2019@gmail.com", "dpdivxmqwngsrgvk");
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        smtp.Send(mail2);
                        Response.Write("<script>alert('Password Send To Your Email')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('Email Not Foud')</script>");
                }
            }
        }
    }
}