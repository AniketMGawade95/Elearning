using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Admin
{
    public partial class AddTopic : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FullName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }


            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadMasterCourse();
                LoadSubCourse();
            }
        }

        private void LoadMasterCourse()
        {
            string q = "exec fetchMasterCoursesName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList1.DataSource = rdr;
            DropDownList1.DataValueField = "MasterCourseId";
            DropDownList1.DataTextField = "CourseName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("-- Select Master Course --", "0"));
        }
        private void LoadSubCourse()
        {
            string q = "exec fetchSubCoursesName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList2.DataSource = rdr;
            DropDownList2.DataValueField = "SubCourseId";
            DropDownList2.DataTextField = "SubCourseName";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("-- Select Sub Course --", "0"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "0" && DropDownList2.SelectedValue != "0"
                && !string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text)
                && !string.IsNullOrEmpty(TextBox3.Text))
            {
                int mastercourseid = int.Parse(DropDownList1.SelectedValue);
                int subcourseid = int.Parse(DropDownList2.SelectedValue);
                string topicname = TextBox1.Text;
                string videoembedcode = TextBox2.Text;
                int videodurationdeconds = int.Parse(TextBox3.Text);
                string q = $"exec insertTopics '{subcourseid}', '{topicname}', '{videoembedcode}', '{videodurationdeconds}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();



                string durationQuery = "SELECT SUM(VideoDurationSeconds) FROM Topics WHERE SubCourseID = @SubCourseID";
                SqlCommand durationCmd = new SqlCommand(durationQuery, conn);
                durationCmd.Parameters.AddWithValue("@SubCourseID", subcourseid);
                object totalDurationObj = durationCmd.ExecuteScalar();

                // Ensure the result is not null
                int totalDuration = 0;
                if (totalDurationObj != DBNull.Value)
                {
                    totalDuration = Convert.ToInt32(totalDurationObj);
                }

                // 3. Update SubCourse duration
                string updateDurationQuery = "UPDATE SubCourses SET Duration = @Duration WHERE SubCourseID = @SubCourseID";
                SqlCommand updateCmd = new SqlCommand(updateDurationQuery, conn);
                updateCmd.Parameters.AddWithValue("@Duration", totalDuration);
                updateCmd.Parameters.AddWithValue("@SubCourseID", subcourseid);
                updateCmd.ExecuteNonQuery();




                GridView1.DataBind();
                Response.Write("<script>alert('Data inserted Sucessfully!')</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data inserted Successfully!');", true);

               
                DropDownList1.SelectedIndex = 0;
                DropDownList2.SelectedIndex = 0;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";

            }
            else
            {
                Response.Write("<script>alert('Please fill all fields!')</script>");
            }
        }
    }
}