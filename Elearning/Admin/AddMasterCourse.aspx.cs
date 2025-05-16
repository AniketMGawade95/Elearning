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
    public partial class AddMasterCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["FullName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }

            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && !string.IsNullOrEmpty(TextBox1.Text))
            {
                string mastercoursename = TextBox1.Text.Trim();
                string filename = Path.GetFileName(FileUpload1.FileName);
                string extension = Path.GetExtension(filename).ToLower(); // Get file extension

                // Validate file extension
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension== ".gif")
                {
                    string folderPath = Server.MapPath("~/images/");

                    // Create folder if not exists
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string filepath = Path.Combine(folderPath, filename);
                    FileUpload1.SaveAs(filepath);

                    string relativePath = "~/images/" + filename;

                    string q = $"exec insertMasterCourses '{mastercoursename}','{relativePath}'";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();

                    Response.Write("<script>alert('Data inserted Successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Only .jpg, .jpeg, or .png image files are allowed');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Insert Data First');</script>");
            }
        }




        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            FileUpload fileUpload = (FileUpload)row.FindControl("FileUploadEdit");
            HiddenField hiddenPicture = (HiddenField)row.FindControl("HiddenPicture");

            string picturePath = hiddenPicture.Value;

            if (fileUpload.HasFile)
            {
                string filename = Path.GetFileName(fileUpload.FileName);
                string extension = Path.GetExtension(filename).ToLower();

                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                {
                    string folderPath = Server.MapPath("~/images/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string filepath = Path.Combine(folderPath, filename);
                    fileUpload.SaveAs(filepath);

                    picturePath = "~/images/" + filename;
                }
                else
                {
                    Response.Write("<script>alert('Only image files (.jpg, .jpeg, .png, .gif) are allowed.');</script>");
                    e.Cancel = true;
                    return;
                }
            }

            
            e.NewValues["Picture"] = picturePath;
        }










    }
}