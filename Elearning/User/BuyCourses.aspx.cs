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
    public partial class BuyCourses : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                    return;
                }

                FetchMasterCourse();
                FilterCourses();
            }


        }


        protected void FetchMasterCourse()
        {
            string s = "exec Masterlist";
            SqlDataAdapter ada = new SqlDataAdapter(s, conn);
            DataSet ds = new DataSet();
            ada.Fill(ds);

            //Session["MasterCourseName"]=ds.Tables[0].Rows[0][1].ToString();


            DataList1.DataSource = ds;
            DataList1.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FilterCourses(txtSearch.Text.Trim());
        }

        private void FilterCourses(string searchTerm = null)
        {
            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("FilterMasterCourse", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@CourseName", searchTerm);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CourseName", DBNull.Value);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }


        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("courses.aspx");

        //}
        protected void btnViewSubcourses_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ViewSubCourses")
            {
                // Get the MasterCourseID from the CommandArgument
                string masterId = e.CommandArgument.ToString();

                // Redirect to SubCourses.aspx with the selected masterId
                Response.Redirect("courses.aspx?masterId=" + masterId);
            }
        }
    }
}