using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Accounts
{
    public partial class coursedetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int subCourseIDd = int.Parse(Request.QueryString["id"]);
                    LoadCourseDetails(subCourseIDd);
                    //LoadTopics(subCourseID);
                    BindCourses();
                    BindRecentCourses();
                }
                else
                {
                    //Response.Redirect("~/Accounts/Login.aspx");
                }
            }

        }



        private void LoadCourseDetails(int subCourseID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select * from SubCourses where SubCourseID=@SubCourseID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SubCourseID", subCourseID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblCourseName.Text = reader["SubCourseName"].ToString();
                        lblPrice.Text = reader["Price"].ToString();
                        lblRating.Text = reader["Rating"].ToString();
                        //lblDuration.Text = reader["Duration"].ToString();
                        imgCourse.ImageUrl = reader["Picture"].ToString().Replace("~", "");
                    }
                    con.Close();
                }
            }
        }

        private void BindCourses()
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT SubCourseID, SubCourseName, Price, Rating, Picture FROM SubCourses";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptCourses.DataSource = dt;
                        rptCourses.DataBind();
                    }
                }
            }

        }




        private void BindRecentCourses()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT TOP 4 SubCourseID, SubCourseName, Picture, Rating, CreatedAt 
                         FROM SubCourses 
                         ORDER BY CreatedAt DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dlRecentCourses.DataSource = dt;
                dlRecentCourses.DataBind();
            }
        }









    }
}