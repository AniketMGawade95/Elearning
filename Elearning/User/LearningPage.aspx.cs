using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Elearning.User
{
    public partial class LearningPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        //hfSubCourseID.Value = "11"; 
        //        hfSubCourseID.Value = Session["SelectedSubCourseID"].ToString(); 
        //        LoadTopics();
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hfSubCourseID.Value = Session["SelectedSubCourseID"].ToString();
                LoadTopics();

                // Load first video automatically
                int firstTopicID = GetFirstTopicID(Convert.ToInt32(hfSubCourseID.Value));
                if (firstTopicID != -1)
                {
                    ViewState["SelectedTopicID"] = firstTopicID;
                    LoadVideo(firstTopicID);
                    btnDownloadCertificate.Visible = AllTopicsCompleted(); // Will be false initially
                }
            }
        }


        private int GetFirstTopicID(int subCourseID)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 TopicID FROM Topics WHERE SubCourseID = @SubCourseID ORDER BY TopicID ASC",
                conn
            );
            cmd.Parameters.AddWithValue("@SubCourseID", subCourseID);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return result != null ? Convert.ToInt32(result) : -1;
        }



        private void LoadTopics()
        {
            int subCourseID = Convert.ToInt32(hfSubCourseID.Value);
            SqlCommand cmd = new SqlCommand("SELECT TopicID, TopicName FROM Topics WHERE SubCourseID = @SubCourseID", conn);
            cmd.Parameters.AddWithValue("@SubCourseID", subCourseID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rptTopics.DataSource = dt;
            rptTopics.DataBind();
        }

        protected void rptTopics_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int topicID = Convert.ToInt32(e.CommandArgument);
                ViewState["SelectedTopicID"] = topicID;
                LoadVideo(topicID);
                btnDownloadCertificate.Visible = AllTopicsCompleted();
            }
        }

        private void LoadVideo(int topicID)
        {
            SqlCommand cmd = new SqlCommand("SELECT VideoEmbedCode FROM Topics WHERE TopicID = @TopicID", conn);
            cmd.Parameters.AddWithValue("@TopicID", topicID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                ltVideo.Text = dt.Rows[0]["VideoEmbedCode"].ToString();
            }
        }

        protected void btnDownloadAssignment_Click(object sender, EventArgs e)
        {
            int topicID = Convert.ToInt32(ViewState["SelectedTopicID"]);
            string assignment = GetAssignmentContent(topicID);

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 50, 50, 25, 25);
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
                doc.Open();
                doc.Add(new Paragraph(assignment));
                doc.Close();

                byte[] bytes = ms.ToArray();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Assignment.pdf");
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }

        protected void btnMCQTest_Click(object sender, EventArgs e)
        {
            int topicID = Convert.ToInt32(ViewState["SelectedTopicID"]);
            DataTable mcqs = GetMCQs(topicID);

            if (mcqs.Rows.Count == 0)
            {
                // Show message and return early
                Response.Write("<script>alert('No MCQs available for this topic.');</script>");
                return;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
                doc.Open();

                foreach (DataRow row in mcqs.Rows)
                {
                    doc.Add(new Paragraph("Q: " + row["Question"].ToString()));
                    doc.Add(new Paragraph("A. " + row["OptionA"]));
                    doc.Add(new Paragraph("B. " + row["OptionB"]));
                    doc.Add(new Paragraph("C. " + row["OptionC"]));
                    doc.Add(new Paragraph("D. " + row["OptionD"]));
                    doc.Add(new Paragraph(" "));
                }

                doc.Close();

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=MCQTest.pdf");
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }


        protected void btnDownloadCertificate_Click(object sender, EventArgs e)
        {

            SqlCommand mmdd = new SqlCommand("select SubCourseName from SubCourses where SubCourseID='" + Session["SelectedSubCourseID"].ToString() + "'",conn);
            SqlDataAdapter ddaa = new SqlDataAdapter(mmdd);
            DataSet ddss = new DataSet();
            ddaa.Fill(ddss);


            string userName = Session["FullName"].ToString(); 
            string course = ddss.Tables[0].Rows[0][0].ToString(); 

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 50, 50, 25, 25);
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
                doc.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font textFont = FontFactory.GetFont("Arial", 12);

                doc.Add(new Paragraph("Certificate of Completion", titleFont));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph("This certifies that", textFont));
                doc.Add(new Paragraph(userName, titleFont));
                doc.Add(new Paragraph("has successfully completed the course:", textFont));
                doc.Add(new Paragraph(course, titleFont));

                doc.Close();

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Certificate.pdf");
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }

        private string GetAssignmentContent(int topicID)
        {
            SqlCommand cmd = new SqlCommand("SELECT Assignment FROM Assignments WHERE TopicID = @TopicID", conn);
            cmd.Parameters.AddWithValue("@TopicID", topicID);
            conn.Open();
            string content = cmd.ExecuteScalar()?.ToString() ?? "No content found.";
            conn.Close();
            return content;
        }

        private DataTable GetMCQs(int topicID)
        {
            SqlCommand cmd = new SqlCommand("SELECT Question, OptionA, OptionB, OptionC, OptionD, Answer FROM MCQs WHERE TopicID = @TopicID", conn);
            cmd.Parameters.AddWithValue("@TopicID", topicID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //private bool AllTopicsCompleted()
        //{
        //    // Replace with real logic based on user progress
        //    return true;
        //}


        private bool AllTopicsCompleted()
        {
            int subCourseID = Convert.ToInt32(hfSubCourseID.Value);
            int selectedTopicID = Convert.ToInt32(ViewState["SelectedTopicID"]);

            SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 TopicID FROM Topics WHERE SubCourseID = @SubCourseID ORDER BY TopicID DESC",
                conn
            );
            cmd.Parameters.AddWithValue("@SubCourseID", subCourseID);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            if (result != null)
            {
                int lastTopicID = Convert.ToInt32(result);
                return selectedTopicID == lastTopicID;
            }

            return false;
        }





        private DataTable currentMCQs;

        protected void btnShowMCQs_Click(object sender, EventArgs e)
        {
            int topicID = Convert.ToInt32(ViewState["SelectedTopicID"]);
            currentMCQs = GetMCQs(topicID);

            if (currentMCQs.Rows.Count == 0)
            {
                ltMCQResult.Text = "<div class='alert alert-info'>No MCQs available for this topic.</div>";
                pnlMCQs.Visible = true;
                rptMCQs.DataSource = null;
                rptMCQs.DataBind();
                return;
            }

            pnlMCQs.Visible = true;
            ltMCQResult.Text = "";

            rptMCQs.DataSource = currentMCQs;
            rptMCQs.DataBind();

            // Save MCQs in ViewState to access on submit
            ViewState["CurrentMCQs"] = currentMCQs;
        }


        protected void btnSubmitMCQAnswers_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentMCQs"] == null)
            {
                ltMCQResult.Text = "<div class='alert alert-danger'>Please load the MCQs first.</div>";
                return;
            }

            DataTable mcqs = (DataTable)ViewState["CurrentMCQs"];
            int score = 0;

            for (int i = 0; i < mcqs.Rows.Count; i++)
            {
                DataRow row = mcqs.Rows[i];
                string correctAnswer = row["Answer"].ToString().Trim().ToUpper(); // e.g. "A", "B", etc.

                // Find the checkbox controls for this question in the Repeater
                RepeaterItem item = rptMCQs.Items[i];
                bool isCorrect = false;

                // Check which checkboxes are checked
                List<string> selectedOptions = new List<string>();

                if (((CheckBox)item.FindControl("chkOptionA")).Checked) selectedOptions.Add("A");
                if (((CheckBox)item.FindControl("chkOptionB")).Checked) selectedOptions.Add("B");
                if (((CheckBox)item.FindControl("chkOptionC")).Checked) selectedOptions.Add("C");
                if (((CheckBox)item.FindControl("chkOptionD")).Checked) selectedOptions.Add("D");

                // Scoring logic:
                // If multiple correct answers exist, you can compare accordingly.
                // Assuming only one correct answer here:

                if (selectedOptions.Count == 1 && selectedOptions[0] == correctAnswer)
                {
                    isCorrect = true;
                }

                if (isCorrect)
                    score++;
            }

            ltMCQResult.Text = $"<div class='alert alert-success'>Your Score: {score} out of {mcqs.Rows.Count}</div>";
        }





        protected void btnSubmitRating_Click(object sender, EventArgs e)
        {
            int subCourseId = Convert.ToInt32(hfSubCourseID.Value);
            int userId = Convert.ToInt32(Session["UserID"]); // Or however you're storing logged-in user ID
            int rating = Convert.ToInt32(ddlRating.SelectedValue);
            string review = txtReview.Text.Trim();
            DateTime now = DateTime.Now;

            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                // Insert rating
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Ratings (UserID, SubCourseID, Rating, Review, CreatedDate)
                                          VALUES (@UserID, @SubCourseID, @Rating, @Review, @CreatedDate)", con);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@SubCourseID", subCourseId);
                cmd.Parameters.AddWithValue("@Rating", rating);
                cmd.Parameters.AddWithValue("@Review", review);
                cmd.Parameters.AddWithValue("@CreatedDate", now);
                cmd.ExecuteNonQuery();

                // Update average rating
                SqlCommand avgCmd = new SqlCommand(@"SELECT AVG(CAST(Rating AS FLOAT)) FROM Ratings WHERE SubCourseID = @SubCourseID", con);
                avgCmd.Parameters.AddWithValue("@SubCourseID", subCourseId);
                object avgObj = avgCmd.ExecuteScalar();
                double avgRating = avgObj != DBNull.Value ? Convert.ToDouble(avgObj) : 0;

                SqlCommand updateRatingCmd = new SqlCommand(@"UPDATE SubCourses SET Rating = @AvgRating WHERE SubCourseID = @SubCourseID", con);
                updateRatingCmd.Parameters.AddWithValue("@AvgRating", avgRating);
                updateRatingCmd.Parameters.AddWithValue("@SubCourseID", subCourseId);
                updateRatingCmd.ExecuteNonQuery();
            }

            lblRatingMessage.Text = "Thank you for your review!";
            ddlRating.ClearSelection();
            txtReview.Text = "";
        }













    }
}