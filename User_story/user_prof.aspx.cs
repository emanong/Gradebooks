using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace User_story
{
    public partial class user_prof : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                txtuser.Text = "Welcome " + Session["user"].ToString();
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("~/login.aspx");
        }

        protected void gradebook1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/gradebook1.aspx");
        }

        protected void gradebook2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/gradebook2.aspx");
        }
    }
}