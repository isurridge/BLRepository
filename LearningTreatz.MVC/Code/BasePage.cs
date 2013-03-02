using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LearningTreatz
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Request.Browser.IsMobileDevice)
            {
                this.MasterPageFile = "~/Mobile.Master";
            }
        }
		
		protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (Request.Browser.IsMobileDevice)
            {
                foreach (BaseValidator v in this.Validators)
                {
                    v.EnableClientScript = false;
                }
            }
        }
    }
}