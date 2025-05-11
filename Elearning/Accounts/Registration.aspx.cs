using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Accounts
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string role = "user";
            string profilePicFileName = null;

            // Server-side input validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ShowAlert("All fields are required.");
                return;
            }

            if (password != confirmPassword)
            {
                ShowAlert("Passwords do not match.");
                return;
            }

            // Handle image upload
            if (FileUpload1.HasFile)
            {
                string folderPath = Server.MapPath("~/ProfilePics/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(FileUpload1.FileName);
                string filePath = Path.Combine(folderPath, uniqueName);
                FileUpload1.SaveAs(filePath);

                profilePicFileName = "~/ProfilePics/" + uniqueName;
            }

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // Check if email already exists
                    string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkEmailQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            ShowAlert("Email already registered.");
                            return;
                        }
                    }

                    // Insert new user
                    string query = "INSERT INTO Users (Name, Email, Password, Role, ProfilePic) VALUES (@Name, @Email, @Password, @Role, @ProfilePic)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // Ideally hash this
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@ProfilePic", profilePicFileName ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }

                    ClearForm();
                    ShowAlert("User registered successfully!", "Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ShowAlert("Error: " + ex.Message);
            }
        }


        private void ShowAlert(string message, string redirectUrl = null)
        {
            string script = redirectUrl == null
                ? $"alert('{message}');"
                : $"alert('{message}'); window.location='{redirectUrl}';";

            ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            FileUpload1.Attributes.Clear();
        }





    }
}