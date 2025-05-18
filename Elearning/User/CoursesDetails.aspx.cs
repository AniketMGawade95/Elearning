using Elearning.Accounts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.User
{
    public partial class CoursesDetails : System.Web.UI.Page
    {


        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindMasterCourses();
            }

        }

        protected void BindMasterCourses()
        {
            string query = "EXEC GetAllMasterCourses";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            ddlMasterCourses.DataSource = reader;
            ddlMasterCourses.DataTextField = "CourseName";
            ddlMasterCourses.DataValueField = "MasterCourseID";
            ddlMasterCourses.DataBind();

            ddlMasterCourses.Items.Insert(0, new ListItem("Select Master Course", "0"));

            reader.Close();
        }

        protected void ddlMasterCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int masterCourseId = int.Parse(ddlMasterCourses.SelectedValue);

            if (masterCourseId != 0)
            {
                string query = $"EXEC GetCourseDetailsByMasterCourseId {masterCourseId}";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                gvCourseDetails.DataSource = reader;
                gvCourseDetails.DataBind();

                reader.Close();
            }
            else
            {
                gvCourseDetails.DataSource = null;
                gvCourseDetails.DataBind();
            }
        }



    }
}