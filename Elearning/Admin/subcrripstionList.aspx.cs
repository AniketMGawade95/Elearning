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
    public partial class subcrripstionList : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSubscriptions();
                LoadPlanNames();
                LoadMasterCourses();
            }
        }

        void LoadSubscriptions()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("getAllSubscriptionPlans", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvSubscriptions.DataSource = dt;
                gvSubscriptions.DataBind();
            }
        }

        void LoadPlanNames()
        {
            ddlPlanName.Items.Clear();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT PlanName FROM SubscriptionPlans", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddlPlanName.Items.Add(dr["PlanName"].ToString());
                }
            }
        }

        void LoadMasterCourses()
        {
            ddlMasterCourse.Items.Clear();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT MasterCourseID, CourseName FROM MasterCourses", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ddlMasterCourse.Items.Add(new ListItem(dr["CourseName"].ToString(), dr["MasterCourseID"].ToString()));
                }
            }
        }

        protected void ddlMasterCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCourses(Convert.ToInt32(ddlMasterCourse.SelectedValue));
        }

        void LoadSubCourses(int masterCourseId)
        {
            cblSubCourses.Items.Clear();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT SubCourseID, SubCourseName FROM SubCourses WHERE MasterCourseID = @MasterCourseID", conn);
                cmd.Parameters.AddWithValue("@MasterCourseID", masterCourseId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cblSubCourses.Items.Add(new ListItem(dr["SubCourseName"].ToString(), dr["SubCourseID"].ToString()));
                }
            }
        }

        protected void gvSubscriptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int subscriptionId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditSubscription")
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("getSubscriptionPlanDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        hfSubscriptionID.Value = subscriptionId.ToString();
                        ddlPlanName.SelectedValue = dr["PlanName"].ToString();
                        ddlMasterCourse.SelectedValue = dr["MasterCourseID"].ToString();
                        LoadSubCourses(Convert.ToInt32(dr["MasterCourseID"]));
                        string[] selectedSubCourses = dr["SubCourses"].ToString().Split(',');
                        foreach (ListItem item in cblSubCourses.Items)
                        {
                            item.Selected = selectedSubCourses.Contains(item.Text.Trim());
                        }
                        txtPrice.Text = dr["Price"].ToString();
                        txtValidity.Text = dr["Validity"].ToString();
                    }
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "editModalScript", "var editModal = new bootstrap.Modal(document.getElementById('editModal')); editModal.show();", true);
            }
            else if (e.CommandName == "DeleteSubscription")
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("deleteSubscriptionPlan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@PlanID", subscriptionId);
                    cmd.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadSubscriptions();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int price, validity;
            if (!int.TryParse(txtPrice.Text, out price) || !int.TryParse(txtValidity.Text, out validity))
            {
                // Optional: Show validation error
                return;
            }

            string subCourseList = string.Join(",", cblSubCourses.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Text));

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("updateSubscriptionPlan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlanID", Convert.ToInt32(hfSubscriptionID.Value));
                cmd.Parameters.AddWithValue("@PlanName", ddlPlanName.SelectedValue);
                cmd.Parameters.AddWithValue("@Features", subCourseList);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Validity", validity);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadSubscriptions();
        }
    }
}