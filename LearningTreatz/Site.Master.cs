
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningTreatz
{
    public partial class SiteMaster : BaseMaster
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(StateManager.City))
                {
                    this.CityDropDownList.SelectedValue = StateManager.City;
                }
                BindRecent();
            }
        }


        protected void CityDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.Validate("CityChoice");
            if (Page.IsValid)
            {
               StateManager.City = this.CityDropDownList.SelectedValue;
                if (!(this.Page is _Default))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }

        }







        public override void BindRecent()
        {
            var recent = StateManager.RecentlyViewed;
            if (recent.Count > 0)
            {
                this.RecentlyViewedRepeater.DataSource = recent;
                this.RecentlyViewedRepeater.DataBind();
            }
        }


    }
}