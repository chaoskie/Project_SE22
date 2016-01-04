using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Database_Layer;

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

            DataTable dt = Database.RetrieveQuery("SELECT \"URL\", rn FROM (SELECT \"URL\", rownum as rn FROM \"Image\" WHERE rn < " +
                maxLimit + ") WHERE rn > " + lowerLimit);
            //TODO CHECK ME!
        }

        protected void btnPrevPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("content.aspx?page=" + (pageNumber - 1), false);
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("content.aspx?page=" + (pageNumber + 1), false);
        }
    }
}