using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GUI_Handler;

namespace tronpon.Pages
{
    public partial class registreren : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnRegister.Click +=btnRegister_Click;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
           
        }
    }
}