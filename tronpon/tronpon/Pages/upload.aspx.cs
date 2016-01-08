using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GUI_Handler;

namespace tronpon.Pages
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpload.Click +=btnUpload_Click;
        }
        
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string message = "";
            Handler.InsertImage(fileUpload, out message);
        }
    }
}