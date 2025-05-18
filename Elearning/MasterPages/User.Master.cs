using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.MasterPages
{
    public partial class User : System.Web.UI.MasterPage
    {

        // Replace this with actual logged-in user (e.g., Session["UserID"])
        protected int LoggedInUserID = 0;

        string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["FullName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }


            Image1.ImageUrl = Session["ProfilePic"].ToString();
            Label1.Text = Session["FullName"].ToString();




            if (Session["UserID"] != null)
            {
                LoggedInUserID = Convert.ToInt32(Session["UserID"]);
            }
            else
            {
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }

            if (!IsPostBack)
            {
                LoadMessages(); // Directly load chat with admin
            }




        }






        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Accounts/Login.aspx");
        }







        void LoadMessages()
        {
            int adminID = 13;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                m.SenderID,
                m.ReceiverID,
                m.MessageText, 
                m.MessageTime
            FROM Messages m
            WHERE (m.SenderID = @AdminID AND m.ReceiverID = @UserID)
               OR (m.SenderID = @UserID AND m.ReceiverID = @AdminID)
            ORDER BY m.MessageTime", conn);

                cmd.Parameters.AddWithValue("@AdminID", adminID);
                cmd.Parameters.AddWithValue("@UserID", LoggedInUserID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                rptMessages.DataSource = reader;
                rptMessages.DataBind();
            }
        }




        public string GetMessageCss(object senderIdObj)
        {
            int senderId = Convert.ToInt32(senderIdObj);
            return senderId == LoggedInUserID ? "msg msg-right" : "msg msg-left";
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            LoadMessages();
        }



        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMessages();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            int adminID = 13;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Messages (SenderID, ReceiverID, MessageText) VALUES (@SenderID, @ReceiverID, @Text)", conn);
                cmd.Parameters.AddWithValue("@SenderID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@ReceiverID", adminID);
                cmd.Parameters.AddWithValue("@Text", txtMessage.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                txtMessage.Text = "";
            }

            LoadMessages();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "scrollAndFocus", "scrollToBottom(); focusOnMessageBox();", true);
        }











    }
}