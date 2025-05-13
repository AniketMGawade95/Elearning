using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Accounts
{
    public partial class GoogleRegisterHandler : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["name"];
            string email = Request.QueryString["email"];
            string photo = Request.QueryString["picture"];
            string role = "user"; // Default role
            string strongPassword = GenerateStrongPassword();




            if (!string.IsNullOrEmpty(email))
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // Check if user already exists
                    SqlCommand checkCmd = new SqlCommand("SELECT UserID, Name, Email, ProfilePic, Role FROM Users WHERE Email = @Email", con);
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    SqlDataReader reader = checkCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // User exists, create session
                        Session["UserID"] = reader["UserID"];
                        Session["Emailid"] = reader["Email"];
                        Session["FullName"] = reader["Name"];
                        Session["ProfilePic"] = reader["ProfilePic"];
                        Session["Role"] = reader["Role"];
                        reader.Close();
                    }
                    else
                    {
                        reader.Close(); // Close before INSERT

                        string profilePicPath = DownloadGoogleProfilePic(photo); // ← save locally


                        // Insert new user
                        SqlCommand insertCmd = new SqlCommand(
     "INSERT INTO Users (Name, Email, ProfilePic, Role, Password) OUTPUT INSERTED.UserID " +
     "VALUES (@Name, @Email, @Photo, @Role, @Password)", con);

                        insertCmd.Parameters.AddWithValue("@Name", name ?? "Google User");
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Photo", profilePicPath); 
                        insertCmd.Parameters.AddWithValue("@Role", role);
                        insertCmd.Parameters.AddWithValue("@Password", strongPassword);


                        int userId = (int)insertCmd.ExecuteScalar();

                        // Set session
                        Session["UserID"] = userId;
                        Session["Emailid"] = email;
                        Session["FullName"] = name;
                        Session["ProfilePic"] = photo;
                        Session["Role"] = role;
                    }

                    con.Close();
                }

                // Redirect to dashboard
                Response.Redirect("~/User/userDashboard.aspx");
            }
            else
            {
                // Something went wrong
                Response.Redirect("~/Accounts/Registration.aspx?error=missing_email");
            }
        }




        private string GenerateStrongPassword(int length = 16)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }

        private string DownloadGoogleProfilePic(string imageUrl)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string folderPath = Server.MapPath("~/ProfilePics/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string extension = Path.GetExtension(imageUrl);
                    if (string.IsNullOrEmpty(extension) || extension.Contains("?"))
                    {
                        extension = ".jpg"; // default to .jpg
                    }

                    string uniqueName = Guid.NewGuid().ToString() + extension;
                    string fullPath = Path.Combine(folderPath, uniqueName);
                    client.DownloadFile(imageUrl, fullPath);

                    return "~/ProfilePics/" + uniqueName;
                }
            }
            catch (Exception)
            {
                return "~/ProfilePics/default.jpg"; // fallback if image download fails
            }
        }




    }
}