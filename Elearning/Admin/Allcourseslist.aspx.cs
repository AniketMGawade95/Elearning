using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Admin
{
    public partial class Allcourseslist : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                GridView1.DataBind();
                LoadMasterCoursesDropDown();
                LoadSubCoursesDropDown();
                LoadTopicsDropDown();
                LoadGridView();
            }
        }

        protected void LoadMasterCoursesDropDown()
        {
            string q = "exec fetchMasterCoursesName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList1.DataSource = rdr;
            DropDownList1.DataValueField = "MasterCourseID";
            DropDownList1.DataTextField = "CourseName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("---All---", ""));
        }
        protected void LoadSubCoursesDropDown()
        {
            string q = "exec fetchSubCoursesName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList2.DataSource = rdr;
            DropDownList2.DataValueField = "SubCourseID";
            DropDownList2.DataTextField = "SubCourseName";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("---All---", ""));
        }

        protected void LoadTopicsDropDown()
        {
            string q = "exec fetchTopicsName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList3.DataSource = rdr;
            DropDownList3.DataValueField = "TopicID";
            DropDownList3.DataTextField = "TopicName";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("---All---", ""));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }
        protected void LoadGridView()
        {
            string master = DropDownList1.SelectedValue != "---All---" ? DropDownList1.SelectedValue : "";
            string sub = DropDownList2.SelectedValue != "---All---" ? DropDownList2.SelectedValue : "";
            string topic = DropDownList3.SelectedValue != "---All---" ? DropDownList3.SelectedValue : "";

            string q = $"exec CourseDetails '{master}','{sub}','{topic}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            if (!dt.Columns.Contains("FormattedDuration"))
                dt.Columns.Add("FormattedDuration", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                int totalSeconds = Convert.ToInt32(row["TotalDurationInSeconds"]);
                TimeSpan ts = TimeSpan.FromSeconds(totalSeconds);
                row["FormattedDuration"] = ts.ToString(@"hh\:mm\:ss");
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //< asp:GridView ID = "GridView1" runat = "server" AutoGenerateColumns = "False"
            //OnRowDeleting = "GridView1_RowDeleting" DataKeyNames = "SubCourseID" >
            // if you have set DataKeyNames in the GridView as DataKeyNames="CourseID"
            // then you can use the following line to get the id
            //int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            Button del = (Button)GridView1.Rows[e.RowIndex].FindControl("Button2");
            int id = int.Parse(del.CommandArgument);

            string q = $"exec deleteCourseListRow '{id}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            LoadGridView();
        }
    }
}