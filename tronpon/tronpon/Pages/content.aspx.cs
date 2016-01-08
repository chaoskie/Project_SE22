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
        static int pageNumber;//bijhouden van het pagina nummer
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["page"] == null)//controleren of de pagina default is
            {
                pageNumber = 0;
            }
            else if (int.TryParse(Request.QueryString["page"], out pageNumber))//check of er werkelijk pagina nummers zijn toegevoegd
            {
                
            }
            if (pageNumber < 0) pageNumber = 0;
            //bepalen van het minimum en maximum aantal weer te geven afbeeldingen
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

        /// <summary>
        /// afbeeldingen weergeven op de pagina 
        /// </summary>
        /// <param name="content">lijst van in de laten afbeeldingen via URL</param>
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