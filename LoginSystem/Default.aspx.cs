using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["unm"] != null)
            {
                lbl1.Text = "Welcome to Members Area.!";
            }
            else
            {
                //lbl1.Text = "Failed to enter Members Area.!";
                Response.Redirect("/LoginSystem/LoginForm.aspx");

            }


        }
    }
}