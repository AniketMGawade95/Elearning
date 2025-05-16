using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace Elearning.Admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Elearning"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetActiveUsers();
                GetInactiveUsers();
                GetRegisteredUsers();
                GetMasterCourses();
                LoadSalesGraph();
                LoadPieChart();
            }
        }

        void GetActiveUsers()
        {
            SqlCommand cmd = new SqlCommand("sp_GetActiveUsersCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Label1.Text = dt.Rows[0]["ActiveUsers"].ToString();
        }

        void GetInactiveUsers()
        {
            SqlCommand cmd = new SqlCommand("sp_GetInactiveUsersCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Label2.Text = dt.Rows[0]["InactiveUsers"].ToString();
        }

        void GetRegisteredUsers()
        {
            SqlCommand cmd = new SqlCommand("sp_GetRegisteredUsersCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Label3.Text = dt.Rows[0]["RegisteredUsers"].ToString();
        }

        void GetMasterCourses()
        {
            SqlCommand cmd = new SqlCommand("sp_GetMasterCoursesCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Label4.Text = dt.Rows[0]["MasterCourses"].ToString();
        }

        void LoadSalesGraph()
        {
            SqlCommand cmd = new SqlCommand("sp_GetSalesGraphData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Graph.Series["Graph"].Points.Clear();
            foreach (DataRow row in dt.Rows)
            {
                Graph.Series["Graph"].Points.AddXY(Convert.ToDateTime(row["SaleDate"]).ToString("dd-MMM"), row["TotalSales"]);
            }
        }

        void LoadPieChart()
        {
            SqlCommand cmd = new SqlCommand("sp_GetRegisteredUsersCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            int total = Convert.ToInt32(dt1.Rows[0]["RegisteredUsers"]);

            SqlCommand cmd2 = new SqlCommand("sp_GetActiveUsersCount", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int active = Convert.ToInt32(dt2.Rows[0]["ActiveUsers"]);

            SqlCommand cmd3 = new SqlCommand("sp_GetInactiveUsersCount", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            int inactive = Convert.ToInt32(dt3.Rows[0]["InactiveUsers"]);

            pi.Series["PiChart"].Points.Clear();
            pi.Series["PiChart"].Points.AddXY("Active Users", active);
            pi.Series["PiChart"].Points.AddXY("Inactive Users", inactive);
        }
    }
}
