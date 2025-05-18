using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.Admin
{
    public partial class AdminChat : System.Web.UI.Page
    {
        //public int AdminUserID => 1; // Or get from Session if needed
        public int AdminUserID = 0; // Or get from Session if needed

        string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        // Store selected user ID in a hidden field
        //public string SelectedUserID
        //{
        //    get { return hfSelectedUserID.Value; }
        //    set { hfSelectedUserID.Value = value; }
        //}

        public string SelectedUserID
        {
            get { return ViewState["SelectedUserID"]?.ToString(); }
            set { ViewState["SelectedUserID"] = value; }
        }

        public string GetUserCss(string userId)
        {
            return userId == SelectedUserID ? "user-item selected-user" : "user-item";
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] != null)
            {
                AdminUserID = Convert.ToInt32(Session["UserID"]);
            }
            else
            {
                // handle missing session (e.g., redirect to login)
                Response.Redirect("~/Accounts/startingmainpage.aspx");
            }


            if (!IsPostBack)
            {
                LoadUsers();
                if (!string.IsNullOrEmpty(SelectedUserID))
                {
                    LoadMessages();
                }
            }
        }

        void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                u.UserID, 
                u.Name,
                COUNT(m.MessageID) AS UnreadCount
            FROM Users u
            LEFT JOIN Messages m ON m.SenderID = u.UserID 
                                 AND m.ReceiverID = @AdminID 
                                 AND m.IsRead = 0
            WHERE u.Role = 'user'
            GROUP BY u.UserID, u.Name", conn);

                cmd.Parameters.AddWithValue("@AdminID", AdminUserID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                rptUsers.DataSource = reader;
                rptUsers.DataBind();
            }
        }


        protected void UserSelected_Command(object sender, CommandEventArgs e)
        {
            SelectedUserID = e.CommandArgument.ToString();
            LoadUsers();
            LoadMessages();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedUserID))
            {
                LoadMessages();
            }
        }

        void LoadMessages()
        {
            if (string.IsNullOrEmpty(SelectedUserID) || SelectedUserID == "0") return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Mark unread messages from user as read
                SqlCommand markReadCmd = new SqlCommand(
                    @"UPDATE Messages 
              SET IsRead = 1 
              WHERE SenderID = @UserID AND ReceiverID = @AdminID AND IsRead = 0", conn);
                markReadCmd.Parameters.AddWithValue("@UserID", SelectedUserID);
                markReadCmd.Parameters.AddWithValue("@AdminID", AdminUserID);
                markReadCmd.ExecuteNonQuery();

                // Load chat messages
                SqlCommand cmd = new SqlCommand(@"
            SELECT SenderID, ReceiverID, MessageText, MessageTime 
            FROM Messages 
            WHERE (SenderID = @AdminID AND ReceiverID = @UserID) 
               OR (SenderID = @UserID AND ReceiverID = @AdminID) 
            ORDER BY MessageTime", conn);
                cmd.Parameters.AddWithValue("@AdminID", AdminUserID);
                cmd.Parameters.AddWithValue("@UserID", SelectedUserID);

                SqlDataReader reader = cmd.ExecuteReader();
                rptMessages.DataSource = reader;
                rptMessages.DataBind();
            }
        }


        public string GetMessageCss(object senderIdObj)
        {
            int senderId = Convert.ToInt32(senderIdObj);
            return senderId == AdminUserID ? "msg msg-right" : "msg msg-left";
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedUserID) || string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Messages (SenderID, ReceiverID, MessageText) VALUES (@SenderID, @ReceiverID, @Text)", conn);
                cmd.Parameters.AddWithValue("@SenderID", AdminUserID);
                cmd.Parameters.AddWithValue("@ReceiverID", SelectedUserID);
                cmd.Parameters.AddWithValue("@Text", txtMessage.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                txtMessage.Text = "";
            }

            LoadMessages();
        }




    }
}