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
    public partial class Membership : System.Web.UI.Page
    {
        //SqlConnection conn;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //    conn = new SqlConnection(cs);
        //    conn.Open();
        //    if (!IsPostBack)
        //    {
        //        LoadMasterCourse();
        //    }
        //}

        //private void LoadMasterCourse()
        //{
        //    string q = "fetchMasterCoursesName ";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    DropDownList2.DataSource = rdr;
        //    DropDownList2.DataValueField = "MasterCourseID";
        //    DropDownList2.DataTextField = "CourseName";
        //    DropDownList2.DataBind();
        //    DropDownList2.Items.Insert(0, new ListItem("Select Master Course", "0"));
        //}

        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int mastercourseid = int.Parse(DropDownList2.SelectedValue);
        //    string q = $"fetchSubCoursesNameByMasterCourseId {mastercourseid}";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    CheckBoxList1.DataSource = rdr;
        //    CheckBoxList1.DataValueField = "SubCourseID";
        //    CheckBoxList1.DataTextField = "SubCourseName";
        //    CheckBoxList1.DataBind();
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    string q = "select * from SubCourses";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    CheckBoxList1.DataSource = rdr;
        //    CheckBoxList1.DataValueField = "SubCourseID";
        //    CheckBoxList1.DataTextField = "SubCourseName";
        //    CheckBoxList1.DataBind();
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (DropDownList1.SelectedIndex == 0)
        //    {
        //        Response.Write("<script>alert('Please select a plan name');</script>");
        //        return;
        //    }
        //    if (DropDownList2.SelectedIndex == 0)
        //    {
        //        Response.Write("<script>alert('Please select a master course');</script>");
        //        return;
        //    }

        //    string planname = DropDownList1.SelectedValue;
        //    string mastercourse = DropDownList2.SelectedValue;
        //    int mastercourseid = int.Parse(DropDownList2.SelectedValue);

        //    int validity = int.Parse(TextBox1.Text);
        //    int price = int.Parse(TextBox2.Text);

        //    List<int> selectedSubcourseIds = new List<int>();
        //    List<string> selectedSubcourseNames = new List<string>();

        //    foreach (ListItem item in CheckBoxList1.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            selectedSubcourseIds.Add(int.Parse(item.Value));
        //            selectedSubcourseNames.Add(item.Text);
        //        }
        //    }

        //    if (selectedSubcourseNames.Count == 0)
        //    {
        //        Response.Write("<script>alert('Please select at least one sub course');</script>");
        //        return;
        //    }

        //    string features = string.Join(", ", selectedSubcourseNames);


        //    string q = $"exec insertSubscriptionPlans @PlanID OUTPUT,'{planname}', '{features}', '{price}', '{validity}', '{mastercourseid}'";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlParameter outParam = new SqlParameter("@PlanID", System.Data.SqlDbType.Int)
        //    {
        //        Direction = System.Data.ParameterDirection.Output
        //    };
        //    cmd.Parameters.Add(outParam);
        //    cmd.ExecuteNonQuery();
        //    int planId = (int)outParam.Value;

        //    // Insert mapping to subcourses
        //    foreach (int subCourseId in selectedSubcourseIds)
        //    {
        //        string insertMap = "INSERT INTO SubscriptionPlanSubCourses (SubscriptionPlanID, SubCourseID) VALUES (@PlanID, @SubCourseID)";
        //        SqlCommand cmd3 = new SqlCommand(insertMap, conn);
        //        cmd3.Parameters.AddWithValue("@PlanID", planId);
        //        cmd3.Parameters.AddWithValue("@SubCourseID", subCourseId);
        //        cmd3.ExecuteNonQuery();
        //    }

        //    Response.Write("<script>alert('Data inserted successfully');</script>");
        //}







        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadMasterCourse();
            }
        }

        private void LoadMasterCourse()
        {
            string q = "fetchMasterCoursesName ";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList2.DataSource = rdr;
            DropDownList2.DataValueField = "MasterCourseID";
            DropDownList2.DataTextField = "CourseName";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Master Course", "0"));
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mastercourseid = int.Parse(DropDownList2.SelectedValue);
            string q = $"fetchSubCoursesNameByMasterCourseId {mastercourseid}";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            CheckBoxList1.DataSource = rdr;
            CheckBoxList1.DataValueField = "SubCourseID";
            CheckBoxList1.DataTextField = "SubCourseName";
            CheckBoxList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Please select a plan name');</script>");
                return;
            }
            if (DropDownList2.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Please select a master course');</script>");
                return;
            }

            string planname = DropDownList1.SelectedValue;
            string mastercourse = DropDownList2.SelectedValue;
            int mastercourseid = int.Parse(DropDownList2.SelectedValue);

            int validity = int.Parse(TextBox1.Text);
            int price = int.Parse(TextBox2.Text);

            List<int> selectedSubcourseIds = new List<int>();
            List<string> selectedSubcourseNames = new List<string>();

            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    selectedSubcourseIds.Add(int.Parse(item.Value));
                    selectedSubcourseNames.Add(item.Text);
                }
            }

            if (selectedSubcourseNames.Count == 0)
            {
                Response.Write("<script>alert('Please select at least one sub course');</script>");
                return;
            }

            string features = string.Join(", ", selectedSubcourseNames);

            string q = $"exec insertSubscriptionPlans @PlanID OUTPUT,'{planname}', '{features}', '{price}', '{validity}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlParameter outParam = new SqlParameter("@PlanID", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(outParam);
            cmd.ExecuteNonQuery();
            int planId = (int)(outParam.Value);

            foreach (int subCourseId in selectedSubcourseIds)
            {
                string insert = $"insertSubscriptionPlanSubCourses '{planId}','{subCourseId}'";
                SqlCommand cmd2 = new SqlCommand(insert, conn);
                cmd2.ExecuteNonQuery();
            }

            Response.Write("<script>alert('Data inserted successfully');</script>");

            Response.Redirect("~/Admin/subcrripstionList.aspx");
        }







    }
}