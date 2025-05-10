using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elearning.MasterPages
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = Session["ProfilePic"].ToString();
            Label1.Text = Session["FullName"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Accounts/Login.aspx");
        }
    }
}