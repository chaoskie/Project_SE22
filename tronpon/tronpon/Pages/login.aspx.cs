using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GUI_Handler;

namespace tronpon.Pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool vis = !Handler.isUserLoggedIn();

            if (vis)
            {
                btnLogin.Text = "Log in";
                btnLogin.Click += btnLogin_Click;
                message.InnerText = "Hier kunt u inloggen";
            }
            else
            {
                message.InnerText = "Hier kunt u uitloggen";
                btnLogin.Text = "Log out";
                btnLogin.Click += btnLogOut_Click;
            }
            credContainer.Visible = vis;
            RegexValidUname.Enabled = vis;
            reqFieldValidPass.Enabled = vis;
            reqFieldValidUname.Enabled = vis;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Handler.LogoutUser();
            Response.Redirect("login.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
             if (Handler.LoginUser(tbUname.Text, tbPass.Text))
             {
                 Response.Redirect("Home.aspx", false);
                 //succes
             }
             else
             {
                 Response.Write("<script>alert('Oeps, het lijkt erop dat deze combinatie niet bestaat!');</script>");
                 //display fout
             }
        }
    }
}