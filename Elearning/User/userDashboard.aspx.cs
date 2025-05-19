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


                //if (Session["UserID"] != null && Session["Role"] != null)
                //{
                //    string role = Session["Role"].ToString();

                //    // Only apply 7-day check for normal users, not admins
                //    if (role.Equals("User", StringComparison.OrdinalIgnoreCase))
                //    {
                //        int userId = Convert.ToInt32(Session["UserID"]);

                //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                //        {
                //            con.Open();

                //            // Get last login date
                //            string selectQuery = "SELECT LastLoginDate FROM UserLoginTracker WHERE UserID = @UserID";
                //            using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                //            {
                //                cmd.Parameters.AddWithValue("@UserID", userId);
                //                object result = cmd.ExecuteScalar();

                //                if (result != null && result != DBNull.Value)
                //                {
                //                    DateTime lastLoginDate = Convert.ToDateTime(result);
                //                    TimeSpan difference = DateTime.Now - lastLoginDate;

                //                    if (difference.TotalDays > 7)
                //                    {
                //                        // Update status to Inactive in Users table
                //                        string updateStatus = "UPDATE Users SET Status = 'Inactive' WHERE UserID = @UserID";
                //                        using (SqlCommand updateCmd = new SqlCommand(updateStatus, con))
                //                        {
                //                            updateCmd.Parameters.AddWithValue("@UserID", userId);
                //                            updateCmd.ExecuteNonQuery();
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}







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




                // Calculate overall completion
                int totalTopics = 0;
                int totalCompleted = 0;

                foreach (DataRow row in dt.Rows)
                {
                    totalTopics += Convert.ToInt32(row["TotalTopics"]);
                    totalCompleted += Convert.ToInt32(row["CompletedTopics"]);
                }

                int totalIncomplete = totalTopics - totalCompleted;

                // Bind to pie chart
                ChartProgress.Series["Progress"].Points.Clear();
                ChartProgress.Series["Progress"].Points.AddXY("Completed", totalCompleted);
                ChartProgress.Series["Progress"].Points.AddXY("Incomplete", totalIncomplete);

                // Optional styling
                ChartProgress.Series["Progress"]["PieLabelStyle"] = "Outside";
                ChartProgress.Series["Progress"].Label = "#VALX (#PERCENT)";
                ChartProgress.Series["Progress"].LegendText = "#VALX";
                ChartProgress.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;







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