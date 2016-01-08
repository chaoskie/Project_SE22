using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using GUI_Handler;

namespace tronpon.Pages
{
    public partial class content : System.Web.UI.Page
    {
        static int pageNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["page"] == null)
            {
                pageNumber = 0;
            }
            else if (int.TryParse(Request.QueryString["page"], out pageNumber))
            {
                
            }
            if (pageNumber < 0) pageNumber = 0;

            int lowerLimit = pageNumber * 9;
            int maxLimit = (pageNumber + 1) * 9;
            List<string> content = Handler.GetContent(maxLimit, lowerLimit);
            VisualizeContent(content);
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
            for (int i = 1; i < 10; i++)
            {
                if (content.Count >= i)
                {
                    string contextIndex = content[i - 1];

                    if (!String.IsNullOrWhiteSpace(contextIndex))
                    {
                        HtmlAnchor imgOb = (HtmlAnchor)ImageHolder.FindControl("imageOutboundUrl" + i);
                        imgOb.HRef = contextIndex;
                        HtmlImage img = (HtmlImage)imgOb.FindControl("image" + i);
                        img.Src = contextIndex;
                    }
                }
            }
        }
    }
}