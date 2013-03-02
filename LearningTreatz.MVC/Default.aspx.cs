using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningTreatz
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }


        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Request.Browser.IsMobileDevice)
            {
                this.MasterPageFile = "~/MobileHome.Master";
            }
        }


    }
}