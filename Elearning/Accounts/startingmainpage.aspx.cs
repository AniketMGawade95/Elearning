using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            }
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




    }
}