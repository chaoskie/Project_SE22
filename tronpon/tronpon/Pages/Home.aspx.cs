using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Web.UI.WebControls;
using GUI_Handler;

namespace tronpon.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VisualizeContent(Handler.GetContent(6, 0));
        }

        /// <summary>
        /// afbeeldingen weergeven op de pagina 
        /// </summary>
        /// <param name="content">lijst van in de laten afbeeldingen via URL</param>
        public void VisualizeContent(List<string> content)
        {
            for (int i = 1; i < 7; i++)
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