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
            string role = "user";
            string profilePicFileName = null;


            if (FileUpload1.HasFile)
            {
                string folderPath = Server.MapPath("~/ProfilePics/");

                // Create folder if it doesn't exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Create unique filename to avoid overwriting
                string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(FileUpload1.FileName);
                string filePath = Path.Combine(folderPath, uniqueName);
                FileUpload1.SaveAs(filePath);

                // Save the relative path to database
                profilePicFileName = "~/ProfilePics/" + uniqueName;
            }



            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "INSERT INTO Users (Name, Email, Password, Role, ProfilePic) VALUES (@Name, @Email, @Password, @Role, @ProfilePic)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Ideally hash this
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@ProfilePic", profilePicFileName ?? (object)DBNull.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                  

                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";

                    string script = "alert('User registered successfully!'); window.location='Login.aspx';";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessScript", script, true);

                }
            }

            

        }
    }
}