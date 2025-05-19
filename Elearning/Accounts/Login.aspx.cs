using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Accounts
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            conn.Open();

            string email = txtEmail.Text;
            string password = txtpassword.Text;

            SqlCommand cmd = new SqlCommand("select * from Users where Email = @Email and Password=@Password", conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["UserID"] = dr["UserID"].ToString();
                Session["FullName"] = dr["Name"].ToString();
                Session["Role"] = dr["Role"].ToString();
                Session["Emailid"] = dr["Email"].ToString();
                Session["ProfilePic"] = dr["ProfilePic"].ToString();



                int userId = Convert.ToInt32(dr["UserID"]);

                string Role = dr["Role"].ToString();

                string role = dr["Role"].ToString().ToLower();
                conn.Close();




                DateTime now = DateTime.Now;

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();

                    if (Role.Equals("user", StringComparison.OrdinalIgnoreCase))
                    {
                        // Step 1: Get last login (excluding today)
                        string lastLoginQuery = @"
            SELECT TOP 1 LastLoginDate 
            FROM UserLoginTracker 
            WHERE UserID = @UserID 
              AND CAST(LastLoginDate AS DATE) < CAST(GETDATE() AS DATE)
            ORDER BY LastLoginDate DESC";

                        using (SqlCommand lastCmd = new SqlCommand(lastLoginQuery, con))
                        {
                            lastCmd.Parameters.AddWithValue("@UserID", userId);
                            object result = lastCmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                DateTime lastLogin = Convert.ToDateTime(result);
                                TimeSpan gap = now - lastLogin;

                                if (gap.TotalDays > 7)
                                {
                                    string updateStatus = "UPDATE Users SET Status = 'Inactive' WHERE UserID = @UserID";
                                    using (SqlCommand updateCmd = new SqlCommand(updateStatus, con))
                                    {
                                        updateCmd.Parameters.AddWithValue("@UserID", userId);
                                        int rows = updateCmd.ExecuteNonQuery();
                                        System.Diagnostics.Debug.WriteLine("Rows updated to Inactive: " + rows);
                                    }
                                }
                            }
                        }
                    }

                    // Step 2: Insert today's login
                    string insertLogin = "INSERT INTO UserLoginTracker (UserID, LastLoginDate) VALUES (@UserID, @LoginDate)";
                    using (SqlCommand insertCmd = new SqlCommand(insertLogin, con))
                    {
                        insertCmd.Parameters.AddWithValue("@UserID", userId);
                        insertCmd.Parameters.AddWithValue("@LoginDate", now);
                        insertCmd.ExecuteNonQuery();
                    }
                }










                if (role == "admin")
                {
                    Response.Redirect("~/Admin/dashboard.aspx");
                }
                else if (role == "user")
                {
                    
                    Response.Redirect("~/User/userDashboard.aspx");
                }                
                else
                {
                    Response.Write("<script>alert('Unknown Role');</script>");
                }
            }
            else
            {
                conn.Close();
                Response.Write("<script>alert('Invalid credentials');</script>");
            }

        }
    }
}