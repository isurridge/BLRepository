using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningTreatz.MVC.MembersOnly.Admin
{
    public partial class CMSTemplates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].CssClass = "hide";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ceedfc'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
                // e.Row.Attributes.Add("style", "cursor:pointer;");
                //  e.Row.Attributes.Add("onclick", "location='patron_detail.aspx?id=" + e.Row.Cells[0].Text + "'");
                e.Row.Cells[2].Attributes.Add("style", "cursor:pointer;");
                e.Row.Cells[2].Attributes.Add("onclick", "location='/MembersOnly/Admin/TemplateCMS.aspx?page=" + e.Row.Cells[1].Text + "'");
            }
        }







    }
}