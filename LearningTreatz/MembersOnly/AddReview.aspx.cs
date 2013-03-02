using LearningTreatz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningTreatz.MembersOnly
{
    public partial class AddReview : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["reviewId"] != null)
            {
                this.ReviewFormView.DefaultMode = FormViewMode.Edit;
            }

        }

        public void ReviewFormView_InsertItem()
        {
            var item = new LearningTreatz.Core.Review()
            {
                RestaurantId = int.Parse(Request.QueryString["id"]),
                UserId = (Guid)Membership.GetUser().ProviderUserKey,
                Id = -1
            };

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                try
                {
                    item.Contents = item.Contents.Trim();
                    ReviewService db = new ReviewService();
                    db.Create(item, User);
                    Response.Redirect("~/Reviews.aspx?id=" + item.RestaurantId);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Contents", e.Message);
                }

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ReviewFormView_UpdateItem(int id)
        {
            ReviewService db = new ReviewService();
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            LearningTreatz.Core.Review item = db.ReviewToEdit(id, User, userId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                try
                {
                    item.Contents = item.Contents.Trim();
                    db.Update(item, User, userId);
                    Response.Redirect("~/Reviews.aspx?id=" + item.RestaurantId);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Contents", e.Message);
                }
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public LearningTreatz.Core.Review ReviewFormView_GetItem()
        {
            ReviewService db = new ReviewService();
            return db.ReviewToEdit(int.Parse(Request.QueryString["reviewId"].ToString()),
                                   User, 
                                   (Guid)Membership.GetUser().ProviderUserKey);

        }
    }
}