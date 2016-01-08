using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GUI_Handler;

namespace tronpon.Pages
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Handler.isUserLoggedIn())
            {
                btnLog.InnerText = "Logout";
                btnLog.ServerClick += btnLog_ServerClick;
            }
            else
            {
                btnLog.InnerText = "Login";
            }
        }

        void btnLog_ServerClick(object sender, EventArgs e)
        {
            Handler.LogoutUser();
            Response.Redirect("login.aspx");
        }
    }
}