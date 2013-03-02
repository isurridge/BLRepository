using LearningTreatz.Core;
using LearningTreatz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningTreatz
{
    public partial class Reviews : BasePage
    {

        Guid userToCheck;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                userToCheck = (Guid)Membership.GetUser().ProviderUserKey;
            }
        }


        public bool CanEdit(Guid userId)
        {
            return (userId == userToCheck);
        }




        public string FormatRatings(int rating)
        {
            string stars = string.Empty;
            if (rating > 0)
            {
                for (int x = 0; x < rating; x++)
                {
                    stars += "&#9733;";
                }
            }
            return stars;
        }

        protected void RestaurantDetailsView_DataBound(object sender, EventArgs e)
        {
            Restaurant r = ((DetailsView)sender).DataItem as Restaurant;
            if (r != null)
            {
                var recent = from x in StateManager.RecentlyViewed select x.Id;
                if (!recent.Contains(r.Id))
                {
                    StateManager.RecentlyViewed.Add(r);
                    ((BaseMaster)this.Master).BindRecent();
                }
            }


        }

        protected void ReviewsDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["user"] = User;
            if (Membership.GetUser() != null)
            {
                e.InputParameters["userId"] = (Guid)Membership.GetUser().ProviderUserKey;
            }
            else
            {
                e.InputParameters["userId"] = new Guid();
            }
        }

        protected void ReviewsListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            ReviewService db = new ReviewService();
            db.ApproveToggle(int.Parse(e.CommandArgument.ToString()), User);
            this.ReviewsListView.DataBind();
        }

    }
}