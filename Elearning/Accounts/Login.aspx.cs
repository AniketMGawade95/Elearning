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

                string role = dr["Role"].ToString().ToLower();
                conn.Close();

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