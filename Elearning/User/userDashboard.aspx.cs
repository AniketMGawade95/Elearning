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
    public partial class userDashboard : System.Web.UI.Page
    {
        //SqlConnection conn;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string cn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //    conn = new SqlConnection(cn);
        //    conn.Open();


        //    if (!IsPostBack)
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            Response.Redirect("~/Login.aspx");
        //            return;
        //        }

        //        piechart();
        //        subcourcecount();
        //        MasterCourceCount();
        //        incomplete_course();
        //        complete_course();
        //        LoadUserSubCourseProgress();
        //        //  LoadSubCourseProgress();
        //    }
        //}

        //protected void subcourcecount()
        //{
        //    string q = $"EXEC SubCourceCount";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    DataList1.DataSource = reader;
        //    DataList1.DataBind();
        //    reader.Close();
        //}

        //protected void MasterCourceCount()
        //{
        //    string q = $"EXEC MasterCourceCount";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    DataList2.DataSource = reader;
        //    DataList2.DataBind();
        //    reader.Close();
        //}
        //protected void complete_course()
        //{
        //    int user = int.Parse(Session["UserID"].ToString());
        //    string q = $"exec compelete_subcourse_user '{user}'";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    // reader.Read();
        //    DataList3.DataSource = reader;
        //    DataList3.DataBind();
        //    reader.Close();

        //}
        //protected void incomplete_course()
        //{
        //    int user = int.Parse(Session["UserID"].ToString());

        //    string q = $"exec incomplete_subcourse_user '{user}'";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    //reader.Read();
        //    DataList4.DataSource = reader;
        //    DataList4.DataBind();
        //    reader.Close();

        //}
        //protected void piechart()
        //{
        //    int user = int.Parse(Session["UserID"].ToString());

        //    string q = $"exec user_piechart '{user}'";
        //    SqlCommand cmd = new SqlCommand(q, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    Chart1.DataSource = reader;
        //    Chart1.DataBind();
        //    reader.Close();

        //}

        //protected void LoadUserSubCourseProgress()
        //{
        //    int user = int.Parse(Session["UserID"].ToString());

        //    SqlCommand cmd = new SqlCommand("get_subcourse_user", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@userid", user);

        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(rdr);
        //    rdr.Close();

        //    if (!dt.Columns.Contains("ProgressPercent"))
        //    {
        //        dt.Columns.Add("ProgressPercent", typeof(int));

        //        foreach (DataRow row in dt.Rows)
        //        {
        //            int totalVideos = Convert.ToInt32(row["TotalVideo"]);
        //            int watched = Convert.ToInt32(row["VideosWatched"]);
        //            int percent = (totalVideos > 0) ? (watched * 100 / totalVideos) : 0;

        //            row["ProgressPercent"] = percent;
        //        }
        //    }

        //    rptProgressBars.DataSource = dt;
        //    rptProgressBars.DataBind();
        //}

    }
}