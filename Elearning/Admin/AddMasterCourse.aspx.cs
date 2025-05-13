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
                string folderPath = Server.MapPath("~/images/");

                // Check if the folder exists, if not, create it
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
                Response.Write("<script>alert('Insert Data First');</script>");
            }
        }


    }
}