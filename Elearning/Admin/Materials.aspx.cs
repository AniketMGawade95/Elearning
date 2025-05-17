using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Admin
{
    public partial class Materials : System.Web.UI.Page
    {
        SqlConnection conn;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //    conn = new SqlConnection(cs);
        //    conn.Open();

        //    if (!IsPostBack)
        //    {
        //        FileUpload1.Attributes["accept"] = ".pdf";
        //        LoadMasterCourseDropDown();
        //        LoadSubCourseDropDown();
        //        LoadTopicDropDown();
        //    }

        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FullName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }

            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                FileUpload1.Attributes["accept"] = ".pdf";
                LoadMasterCourseDropDown();
                LoadSubCourseDropDown();
                LoadTopicDropDown();

                // Show alert after redirect
                if (Session["Success"] != null)
                {
                    string message = Session["Success"].ToString();
                    Session["Success"] = null;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
                }
            }
        }



        private void LoadMasterCourseDropDown()
        {
            string q = "exec fetchMasterCoursesName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList1.DataSource = rdr;
            DropDownList1.DataValueField = "MasterCourseId";
            DropDownList1.DataTextField = "CourseName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "-- Select Master Course --");
        }


        //private void LoadSubCourseDropDown(int masterCourseId = 0)
        //{
        //    string q = masterCourseId > 0 ? $"exec fetchTopicsNameBySubCourseId '{subCourseId}'" : "exec fetchSubCoursesName";
        private void LoadSubCourseDropDown()
        {
            string q = "exec fetchSubCoursesName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList2.DataSource = rdr;
            DropDownList2.DataValueField = "SubCourseID";
            DropDownList2.DataTextField = "SubCourseName";
            DropDownList2.DataBind();

            DropDownList2.Items.Insert(0, "-- Select Sub Course --");
        }

        //private void LoadTopicDropDown(int subCourseId = 0)
        //{
        //    string q = subCourseId > 0 ? $"exec fetchSubCoursesNameByMasterCourseId '{subCourseId}'" : "exec fetchTopicsName";
        private void LoadTopicDropDown()
        {
            string q = "exec fetchTopicsName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList3.DataSource = rdr;
            DropDownList3.DataValueField = "TopicID";
            DropDownList3.DataTextField = "TopicName";
            DropDownList3.DataBind();

            DropDownList3.Items.Insert(0, "-- Select Topics --");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DropDownList1.SelectedIndex != 0)
            //{
            //    int masterCourseId = int.Parse(DropDownList1.SelectedValue);
            //    LoadSubCourseDropDown(masterCourseId);

            //    string q1 = $"exec fetchTopicsNameByMasterCourseId {masterCourseId}";
            //SqlCommand cmd1 = new SqlCommand(q1, conn);
            //SqlDataReader rdr1 = cmd1.ExecuteReader();
            //DropDownList3.DataSource = rdr1;
            //DropDownList3.DataValueField = "TopicID";
            //DropDownList3.DataTextField = "TopicName";
            //DropDownList3.DataBind();

            //DropDownList3.Items.Insert(0, "-- Select Topics --");
            //}

            if (DropDownList1.SelectedIndex != 0)
            {
                int masterCourseId = int.Parse(DropDownList1.SelectedValue);

                string q = $"exec fetchSubCoursesNameByMasterCourseId {masterCourseId}";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList2.DataSource = rdr;
                DropDownList2.DataValueField = "SubCourseID";
                DropDownList2.DataTextField = "SubCourseName";
                DropDownList2.DataBind();

                DropDownList2.Items.Insert(0, "-- Select Sub Course --");

                string q1 = $"exec fetchTopicsNameByMasterCourseId {masterCourseId}";
                SqlCommand cmd1 = new SqlCommand(q1, conn);
                SqlDataReader rdr1 = cmd1.ExecuteReader();
                DropDownList3.DataSource = rdr1;
                DropDownList3.DataValueField = "TopicID";
                DropDownList3.DataTextField = "TopicName";
                DropDownList3.DataBind();

                DropDownList3.Items.Insert(0, "-- Select Topics --");
            }

            else
            {
                // Reset both SubCourse and Topics
                DropDownList2.Items.Clear();
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "-- Select Sub Course --");

                DropDownList3.Items.Clear();
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, "-- Select Topics --");
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (DropDownList2.SelectedIndex != 0)
            //{
            //    int subCourseId = int.Parse(DropDownList2.SelectedValue);
            //    LoadTopicDropDown(subCourseId);
            //}
            if (DropDownList2.SelectedIndex != 0)
            {
                int subCourseId = int.Parse(DropDownList2.SelectedValue);

                //string q1 = $"exec fetchMasterCourseNameBySubCourseId '{subCourseId}' ";
                //SqlCommand cmd1 = new SqlCommand (q1, conn);
                //SqlDataReader rdr1 = cmd1.ExecuteReader();
                //DropDownList1.DataSource = rdr1;
                //DropDownList1.DataValueField = "MasterCourseId";
                //DropDownList1.DataTextField = "CourseName";
                //DropDownList1.DataBind();

                //DropDownList1.Items.Insert(0, "--Select MasterCourse--");

                string q2 = $"exec fetchTopicsNameBySubCourseId '{subCourseId}' ";
                SqlCommand cmd2 = new SqlCommand(q2, conn);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                DropDownList3.DataSource = rdr2;
                DropDownList3.DataValueField = "TopicID";
                DropDownList3.DataTextField = "TopicName";
                DropDownList3.DataBind();

                DropDownList3.Items.Insert(0, "-- Select Topics --");
            }
            else
            {
                //// Reset both masterCourse and Topics
                //DropDownList1.Items.Clear();
                //DropDownList1.DataBind();
                //DropDownList1.Items.Insert(0, "-- Select MasterCourse --");

                DropDownList3.Items.Clear();
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, "-- Select Topics --");
            }

        }

        //protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(DropDownList3.SelectedIndex !=0){

        //        int topicid = int.Parse(DropDownList3.SelectedValue);

        //        string q1 = $"exec fetchMasterCourseNameByTopicId '{topicid}'";
        //        SqlCommand cmd1 = new SqlCommand(q1, conn);
        //        SqlDataReader rdr1 = cmd1.ExecuteReader();
        //        DropDownList1.DataSource = rdr1;
        //        DropDownList1.DataValueField = "MasterCourseId";
        //        DropDownList1.DataTextField = "CourseName";
        //        DropDownList1.DataBind();
        //        DropDownList1.Items.Insert(0, "--Select MasterCourse--");

        //        string q2 = $"exec fetchSubCourseNameByTopicId '{topicid}'";
        //        SqlCommand cmd2 = new SqlCommand( q2, conn);
        //        SqlDataReader rdr2 = cmd2.ExecuteReader();
        //        DropDownList2.DataSource = rdr2;
        //        DropDownList2.DataValueField = "SubCourseId";
        //        DropDownList2.DataTextField = "SubCourseName";
        //        DropDownList2.DataBind();
        //        DropDownList2.Items.Insert(0, "--Select SubCourse--");
        //    }
        //    else
        //    {
        //        // Reset both mastercourse and SubCourse
        //        DropDownList1.Items.Clear();
        //        DropDownList1.DataBind();
        //        DropDownList1.Items.Insert(0, "-- Select MasterCourse --");

        //        DropDownList2.Items.Clear();
        //        DropDownList2.DataBind();
        //        DropDownList2.Items.Insert(0, "-- Select SubCourse --");
        //    }
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    // File extension check
        //    string fileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
        //    if (fileExt != ".pdf")
        //    {
        //        Response.Write("<script>alert('Only PDF files are allowed');</script>");
        //        return;
        //    }

        //    //if (DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0 || !FileUpload1.HasFile)
        //    //{
        //    //    Response.Write("<script>alert('Please select all dropdowns and upload a PDF');</script>");
        //    //    return;
        //    //}

        //    int topicId = int.Parse(DropDownList3.SelectedValue);
        //    string[] questions = Request.Form.GetValues("question");
        //    string[] optionAs = Request.Form.GetValues("optionA");
        //    string[] optionBs = Request.Form.GetValues("optionB");
        //    string[] optionCs = Request.Form.GetValues("optionC");
        //    string[] optionDs = Request.Form.GetValues("optionD");
        //    string[] answers = Request.Form.GetValues("answer");

        //    //if (questions == null || optionAs == null || answers == null)
        //    //{
        //    //    Response.Write("<script>alert('Please enter at least one MCQ');</script>");
        //    //    return;
        //    //}

        //    if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0 && DropDownList3.SelectedIndex != 0
        //        && FileUpload1.HasFile && questions != null && optionAs != null && optionBs != null && optionCs != null
        //        && optionDs != null && answers != null)
        //    {
        //        int topicid = int.Parse(DropDownList3.SelectedValue);

        //        string filename = Path.GetFileName(FileUpload1.FileName);

        //        string filepath = Server.MapPath("PDF/") + filename;



        //        FileUpload1.SaveAs(filepath);
        //        String relativepath = ("PDF/") + filename;

        //        string q = $"exec insertAssignments '{topicid}','{relativepath}' ";
        //        SqlCommand cmd = new SqlCommand(q, conn);
        //        cmd.ExecuteNonQuery();

        //        for (int i = 0; i < questions.Length; i++)
        //        {
        //            string query = $"exec insertMCQs '{topicid}','{questions[i]}','{optionAs[i]}','{optionBs[i]}'," +
        //                $"'{optionCs[i]}','{optionDs[i]}','{answers[i]}' ";
        //            SqlCommand sqlcmd = new SqlCommand(query, conn);
        //            sqlcmd.ExecuteNonQuery();
        //        }

        //        Response.Write("<script>alert('Data inserted Sucessfully')</script>");
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Select and fill data first')</script>");
        //    }
        //}


        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    // File extension check
        //    string fileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
        //    if (fileExt != ".pdf")
        //    {
        //        Response.Write("<script>alert('Only PDF files are allowed');</script>");
        //        return;
        //    }

        //    int topicId = int.Parse(DropDownList3.SelectedValue);
        //    string[] questions = Request.Form.GetValues("question");
        //    string[] optionAs = Request.Form.GetValues("optionA");
        //    string[] optionBs = Request.Form.GetValues("optionB");
        //    string[] optionCs = Request.Form.GetValues("optionC");
        //    string[] optionDs = Request.Form.GetValues("optionD");
        //    string[] answers = Request.Form.GetValues("answer");

        //    if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0 && DropDownList3.SelectedIndex != 0
        //        && FileUpload1.HasFile && questions != null && optionAs != null && optionBs != null && optionCs != null
        //        && optionDs != null && answers != null)
        //    {
        //        int topicid = int.Parse(DropDownList3.SelectedValue);

        //        string filename = Path.GetFileName(FileUpload1.FileName);
        //        string folderPath = Server.MapPath("~/PDF/");

        //        // ✅ Create folder if it doesn't exist
        //        if (!Directory.Exists(folderPath))
        //        {
        //            Directory.CreateDirectory(folderPath);
        //        }

        //        string filepath = Path.Combine(folderPath, filename);
        //        FileUpload1.SaveAs(filepath);
        //        string relativepath = "~/PDF/" + filename;

        //        string q = $"exec insertAssignments '{topicid}','{relativepath}'";
        //        SqlCommand cmd = new SqlCommand(q, conn);
        //        cmd.ExecuteNonQuery();

        //        for (int i = 0; i < questions.Length; i++)
        //        {
        //            string query = $"exec insertMCQs '{topicid}','{questions[i]}','{optionAs[i]}','{optionBs[i]}'," +
        //                $"'{optionCs[i]}','{optionDs[i]}','{answers[i]}'";
        //            SqlCommand sqlcmd = new SqlCommand(query, conn);
        //            sqlcmd.ExecuteNonQuery();
        //        }

        //        Response.Write("<script>alert('Data inserted Successfully')</script>");
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Select and fill data first')</script>");
        //    }
        //}





        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
            if (fileExt != ".pdf")
            {
                Response.Write("<script>alert('Only PDF files are allowed');</script>");
                return;
            }

            string[] questions = Request.Form.GetValues("question");
            string[] optionAs = Request.Form.GetValues("optionA");
            string[] optionBs = Request.Form.GetValues("optionB");
            string[] optionCs = Request.Form.GetValues("optionC");
            string[] optionDs = Request.Form.GetValues("optionD");
            string[] answers = Request.Form.GetValues("answer");

            if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0 && DropDownList3.SelectedIndex != 0
                && FileUpload1.HasFile && questions != null && optionAs != null && optionBs != null && optionCs != null
                && optionDs != null && answers != null)
            {
                int topicid = int.Parse(DropDownList3.SelectedValue);
                string filename = Path.GetFileName(FileUpload1.FileName);
                string folderPath = Server.MapPath("~/PDF/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filepath = Path.Combine(folderPath, filename);
                FileUpload1.SaveAs(filepath);
                string relativepath = "~/PDF/" + filename;

                string q = $"exec insertAssignments '{topicid}','{relativepath}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();

                for (int i = 0; i < questions.Length; i++)
                {
                    string query = $"exec insertMCQs '{topicid}','{questions[i]}','{optionAs[i]}','{optionBs[i]}'," +
                        $"'{optionCs[i]}','{optionDs[i]}','{answers[i]}'";
                    SqlCommand sqlcmd = new SqlCommand(query, conn);
                    sqlcmd.ExecuteNonQuery();
                }

                // Instead of alert, redirect to avoid resubmission
                Session["Success"] = "Data inserted successfully!";
                Response.Redirect(Request.RawUrl); // redirects to same page
            }
            else
            {
                Response.Write("<script>alert('Select and fill data first');</script>");
            }
        }






    }
}