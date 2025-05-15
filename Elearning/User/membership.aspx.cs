using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Elearning.User
{
    public partial class membership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPlans();
            }
        }

        private void LoadPlans()
        {
            string cs = ConfigurationManager.ConnectionStrings["Elearning"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_GetAllSubscriptionPlans", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            rptPlans.DataSource = dt;
            rptPlans.DataBind();
        }
    }
}
