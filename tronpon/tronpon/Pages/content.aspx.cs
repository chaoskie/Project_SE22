using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GUI_Handler;

namespace tronpon.Pages
{
    public partial class content : System.Web.UI.Page
    {
        int pageNumber = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageNumber = Convert.ToInt32(Request.QueryString["page"]);
            int lowerLimit = pageNumber * 9;
            int maxLimit = (pageNumber + 1) * 9;
            List<string> content = Handler.GetContent(maxLimit, lowerLimit);
        }

        protected void btnPrevPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("content.aspx?page=" + (pageNumber - 1), false);
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("content.aspx?page=" + (pageNumber + 1), false);
        }

        public void VisualizeContent(List<string> content)
        {
            imageOutboundUrl1.HRef = content[0];
            image1.Src = content[0];
        }
    }
}