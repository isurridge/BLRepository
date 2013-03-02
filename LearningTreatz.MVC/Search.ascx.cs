using LearningTreatz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningTreatz
{
    public partial class Search : System.Web.UI.UserControl
    {

        public bool EnableClientScript
        {
            get
            {
                return this.SearchRequiredFieldValidator.EnableClientScript;
            }
            set
            {
                this.SearchRequiredFieldValidator.EnableClientScript = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RestaurantService db = new RestaurantService();
                var ids = db.RestaurantIds(this.SearchTextBox.Text);
                if (ids.Count() > 0)
                {
                    Response.Redirect("~/Reviews.aspx?id=" + ids.First());
                }

            }

        }

    }
}