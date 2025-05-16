using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Accounts
{
    public partial class course : System.Web.UI.Page
    {
        public static int PageSize = 6;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSubCourses(1);
            }
        }

        private void BindSubCourses(int pageIndex)
        {
            string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SubCourseID, SubCourseName, Price, Duration, Picture FROM SubCourses", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                PagedDataSource pagedData = new PagedDataSource();
                pagedData.DataSource = dt.DefaultView;
                pagedData.AllowPaging = true;
                pagedData.PageSize = PageSize;
                pagedData.CurrentPageIndex = pageIndex - 1;

                rptSubCourses.DataSource = pagedData;
                rptSubCourses.DataBind();

                // Build Paging UI
                DataTable dtPages = new DataTable();
                dtPages.Columns.Add("PageNumber");
                dtPages.Columns.Add("IsCurrent", typeof(bool));

                for (int i = 1; i <= pagedData.PageCount; i++)
                {
                    dtPages.Rows.Add(i, i == pageIndex);
                }

                rptPaging.DataSource = dtPages;
                rptPaging.DataBind();
            }
        }

        protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                int pageIndex = Convert.ToInt32(e.CommandArgument);
                BindSubCourses(pageIndex);
            }
        }

        protected void rptSubCourses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("CourseDetails.aspx?id=" + id);
            }
        }


    }
}