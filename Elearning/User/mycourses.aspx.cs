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
    public partial class mycourses : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FullName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }

            LoadCourses();

        }

        private void LoadCourses()
        {
            //int userId = 1;
            int userId = Convert.ToInt32(Session["UserID"]);


            string cnf = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            //SqlCommand cmdd = new SqlCommand("select SubCourseID from MyCourses where UserID='" + userId + "'", conn);

            string q = $"exec GetMyCourses {userId}";
            SqlDataAdapter ada = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            ada.Fill(ds);



            DatalistCourse.DataSource = ds;
            DatalistCourse.DataBind();
        }

        protected void btnGetCourse_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/User/LearningPage.aspx");
        }
    }
}