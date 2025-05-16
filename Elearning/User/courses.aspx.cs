using Elearning.MasterPages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.User
{
    public partial class courses : System.Web.UI.Page
    {
        SqlConnection conn;
        int masterId; // Store masterId globally for this page

        protected void Page_Load(object sender, EventArgs e)
        {
            

            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();

            // Get masterId from query string
            if (!string.IsNullOrEmpty(Request.QueryString["masterId"]))
            {
                int.TryParse(Request.QueryString["masterId"], out masterId);
            }
            //else
            //{
            //    // Optional: redirect or show error if masterId is not present
            //    Response.Redirect("Default.aspx");
            //    return;
            //}

            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                    return;
                }

                FetchCourse();
                //FilterCourses(); // This uses txtSearch if filled
            }
        }

        public void FetchCourse()
        {
            using (SqlCommand cmd = new SqlCommand("fetchcourse", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MasterCourseID", masterId);



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DatalistCourse.DataSource = dt;
                DatalistCourse.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FilterCourses(txtSearch.Text.Trim());
        }




        private void FilterCourses(string searchTerm = null)
        {
            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("FilterCourse", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MasterCourseID", masterId); // <-- Add masterId filtering

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@SubCourseName", searchTerm);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SubCourseName", DBNull.Value);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DatalistCourse.DataSource = dt;
                DatalistCourse.DataBind();
            }
        }
        protected void btnBuyCourse_Command(object sender, CommandEventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

             int scid= int.Parse(e.CommandArgument.ToString());



            SqlCommand mmd = new SqlCommand("SELECT COUNT(*) FROM Cart WHERE SubCourseID = @SubCourseID AND UserID = @UserID", conn);
            mmd.Parameters.AddWithValue("@SubCourseID", scid);
            mmd.Parameters.AddWithValue("@UserID", int.Parse(Session["UserID"].ToString())); // Assuming you're filtering by user too

            int count = (int)mmd.ExecuteScalar();


            SqlCommand mmdd = new SqlCommand("SELECT COUNT(*) FROM MyCourses WHERE SubCourseID = @SubCourseID AND UserID = @UserID", conn);
            mmdd.Parameters.AddWithValue("@SubCourseID", scid);
            mmdd.Parameters.AddWithValue("@UserID", int.Parse(Session["UserID"].ToString())); // Assuming you're filtering by user too

            int countt = (int)mmdd.ExecuteScalar();

            if (count > 0 )
            {
                // Course already added
                Response.Write("<script>alert('This course is already selected.');</script>");
            }
            else if (countt > 0)
            {
                Response.Write("<script>alert('You Have Already Purchaced This Course.');</script>");
            }
            else
            {
                int subCourseId = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(Session["UserID"]);

                string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Cart (UserID, SubCourseID) VALUES (@UserID, @SubCourseID)", conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@SubCourseID", subCourseId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                //Response.Redirect("~/User/Cart.aspx");
            }




        }







    }
}