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
    public partial class AddSubCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FullName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }

            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                fetchDropDownList();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "0" &&
     !string.IsNullOrWhiteSpace(TextBox1.Text) &&
     !string.IsNullOrWhiteSpace(TextBox2.Text) &&
     FileUpload1.HasFile)
            {
                if (int.TryParse(DropDownList1.SelectedValue, out int masterCourseId) &&
                    int.TryParse(TextBox2.Text.Trim(), out int price) && price >= 0)
                {
                    string subCourseName = TextBox1.Text.Trim();

                    // Save file safely
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string extension = Path.GetExtension(filename).ToLower();

                    // Validate file type
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                    if (!allowedExtensions.Contains(extension))
                    {
                        Response.Write("<script>alert('Only image files (.jpg, .png, .gif) are allowed.');</script>");
                        return;
                    }

                    string folderPath = Server.MapPath("~/images/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fullPath = Path.Combine(folderPath, filename);
                    FileUpload1.SaveAs(fullPath);

                    string relativePath = "~/images/" + filename; // FIXED HERE

                    // Insert using parameterized query
                    string query = "exec insertSubCourses @MasterCourseID, @SubCourseName, @Price, @PicturePath";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MasterCourseID", masterCourseId);
                        cmd.Parameters.AddWithValue("@SubCourseName", subCourseName);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@PicturePath", relativePath);

                        cmd.ExecuteNonQuery();
                    }

                    GridView1.DataBind();
                    Response.Write("<script>alert('Data inserted successfully!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Please enter valid numeric values.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('All fields are required.');</script>");
            }


        }

        private void fetchDropDownList()
        {
            string q = "exec fetchMasterCoursesName";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList1.DataSource = rdr;
            DropDownList1.DataTextField = "CourseName";
            DropDownList1.DataValueField = "MasterCourseID";
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("-- Select Master Course --", "0"));
        }




        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            FileUpload fileUpload = (FileUpload)row.FindControl("FileUploadEdit");
            HiddenField hiddenOldImage = (HiddenField)row.FindControl("HiddenOldImage");

            string newImagePath = hiddenOldImage.Value; // default to old one

            if (fileUpload != null && fileUpload.HasFile)
            {
                string extension = Path.GetExtension(fileUpload.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                if (!allowedExtensions.Contains(extension))
                {
                    Response.Write("<script>alert('Only image files (.jpg, .png, .gif) are allowed.');</script>");
                    e.Cancel = true;
                    return;
                }

                string folderPath = Server.MapPath("~/images/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Path.GetFileName(fileUpload.FileName);
                string fullPath = Path.Combine(folderPath, fileName);
                fileUpload.SaveAs(fullPath);
                newImagePath = "~/images/" + fileName;
            }

            e.NewValues["Picture"] = newImagePath;
        }










    }
}