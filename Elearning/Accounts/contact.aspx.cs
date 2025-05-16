using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Accounts
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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