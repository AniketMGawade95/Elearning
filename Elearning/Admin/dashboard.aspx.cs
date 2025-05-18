using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Elearning.Admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {




            if (!IsPostBack)
            {
                LoadActiveUsers();
                LoadInactiveUsers();
                LoadMasterCourses();
                LoadSubCourses();
                LoadSalesChart();
                LoadPieChart();
                LoadSalesYearDropdown();
                LoadMasterCourseDropdown();

                //BindYearDropdown();
            }
        }





        void LoadActiveUsers()
        {
            SqlCommand cmd = new SqlCommand("count_is_Active", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        void LoadInactiveUsers()
        {
            SqlCommand cmd = new SqlCommand("count_is_inActive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataList2.DataSource = dt;
            DataList2.DataBind();
        }

        void LoadMasterCourses()
        {
            SqlCommand cmd = new SqlCommand("master_course_count", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataList3.DataSource = dt;
            DataList3.DataBind();
        }

        void LoadSubCourses()
        {
            SqlCommand cmd = new SqlCommand("sub_course_count", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataList4.DataSource = dt;
            DataList4.DataBind();
        }

        protected void BindYearDropdown()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT YEAR(SaleDate) AS SaleYear FROM Sales ORDER BY SaleYear DESC", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("Select Year", "0"));
            while (dr.Read())
            {
                DropDownList2.Items.Add(new ListItem(dr["SaleYear"].ToString(), dr["SaleYear"].ToString()));
            }
            dr.Close();

            con.Close();
        }





        protected void LoadSalesChart()
        {
            int selectedYear = 2020;
            con.Open();
            SqlCommand cmd = new SqlCommand("sale_data", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@year", selectedYear);
            SqlDataReader dr = cmd.ExecuteReader();


            Chart2.Series["Sales"].Points.DataBind(dr, "month", "count", null);
            dr.Close();
            con.Close();

        }


        void LoadPieChart()
        {
            SqlCommand cmd = new SqlCommand("piechart", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Chart3.DataSource = dt;
            Chart3.Series["user"].XValueMember = "Status";
            Chart3.Series["user"].YValueMembers = "UserCount";
            Chart3.DataBind();
        }

        void LoadSalesYearDropdown()
        {
            SqlCommand cmd = new SqlCommand("sales_dropdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "year";
            DropDownList2.DataValueField = "year";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("--Select Year--", "0"));
        }


        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownList2.SelectedValue != "0")
        //    {
        //        string selectedYear = DropDownList2.SelectedValue;
        //        BindSalesChart(selectedYear);
        //    }

        //    if (DropDownList2.SelectedValue != "0")
        //    {
        //        SqlCommand cmd = new SqlCommand("sale_data", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@year", DropDownList2.SelectedValue);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);



        //        Chart2.DataSource = dt;
        //        Chart2.Series["Sales"].XValueMember = "month";
        //        Chart2.Series["Sales"].YValueMembers = "count";
        //        Chart2.DataBind();
        //    }
        //}

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(DropDownList2.SelectedValue);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Duplicate"].ConnectionString);
            SqlCommand cmd = new SqlCommand("sp_GetSalesGraphData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Year", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Chart2.Series["Sales"].Points.DataBind(dt.DefaultView, "month", "count", "");
        }

        protected void sales_dropdown()
        {
            con.Open();
            string query = "exec sales_dropdown";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();

            DropDownList2.DataSource = rdr;
            DropDownList2.DataTextField = "Title";
            DropDownList2.DataValueField = "MasterCourseId";
            DropDownList2.DataBind();

            rdr.Close();
            con.Close();
        }

        protected void BindSalesChart(string selectedYear)
        {
            SqlCommand cmd = new SqlCommand("sp_GetSalesGraphData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Year", selectedYear);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Chart2.Series["Sales"].Points.DataBind(dt.DefaultView, "Month", "TotalSales", null);
        }

        void LoadMasterCourseDropdown()
        {
            SqlCommand cmd = new SqlCommand("dropdown1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "Title";
            DropDownList3.DataValueField = "MasterCourseID";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("--Select Course--", "0"));
        }



        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue != "0")
            {
                SqlCommand cmd = new SqlCommand("dropdown_grid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", DropDownList3.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }









    }
}
