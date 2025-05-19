using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.User
{
    public partial class userDashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gettotalcourses();
                gettotaltopics();
                LoadCourseProgress();
            }
            
        }

        private void LoadCourseProgress()
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());

            string query = @"
        SELECT 
            mc.SubCourseID,
            mc.SubCourseName,
            mc.Picture,
            mc.Duration,
            COUNT(DISTINCT t.TopicID) AS TotalTopics,
            COUNT(DISTINCT tc.TopicID) AS CompletedTopics
        FROM MyCourses mc
        LEFT JOIN Topics t ON mc.SubCourseID = t.SubCourseID
        LEFT JOIN TopicCompletion tc 
            ON tc.TopicID = t.TopicID AND tc.UserID = mc.UserID
        WHERE mc.UserID = @UserID
        GROUP BY mc.SubCourseID, mc.SubCourseName, mc.Picture, mc.Duration";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
               
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                // Add ProgressPercent column
                dt.Columns.Add("ProgressPercent", typeof(int));
                foreach (DataRow row in dt.Rows)
                {
                    int total = Convert.ToInt32(row["TotalTopics"]);
                    int completed = Convert.ToInt32(row["CompletedTopics"]);
                    int percent = (total == 0) ? 0 : (completed * 100 / total);
                    row["ProgressPercent"] = percent;
                }

                rptProgress.DataSource = dt;
                rptProgress.DataBind();
            }
        }


        public void gettotalcourses()
        {
            SqlCommand cmd = new SqlCommand("select count(SubCourseID) from MyCourses where UserID = @userid", con);

            int userid = Convert.ToInt32(Session["UserID"].ToString());
            cmd.Parameters.AddWithValue("@userid",userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            subcoursescount.Text = ds.Tables[0].Rows[0][0].ToString();
        }
       

        public void gettotaltopics()
        {
            SqlCommand cmd = new SqlCommand("select count(TopicID) from Topics inner join MyCourses on Topics.SubCourseID=MyCourses.SubCourseID where UserID=@userid", con);

            int userid = Convert.ToInt32(Session["UserID"].ToString());
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            totalnumbertopics.Text = ds.Tables[0].Rows[0][0].ToString();
        }


    }
}