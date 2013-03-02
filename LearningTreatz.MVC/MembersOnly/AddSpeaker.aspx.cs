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
    public partial class AddSpeaker : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["Id"] != null)
            {
                this.SpeakerFormView.DefaultMode = FormViewMode.Edit;
            }

        }





        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public LearningTreatz.Core.Speaker SpeakerFormView_GetItem()
        {
            SpeakerService db = new SpeakerService();
            return db.SpeakerToEdit(int.Parse(Request.QueryString["Id"].ToString()),
                                   User,
                                   (Guid)Membership.GetUser().ProviderUserKey);

        }


         protected void InsertButton_Command(object sender, CommandEventArgs e)
        {
            SpeakerFormView_InsertItem();
        }



        protected void UpdateButton_Command(object sender, CommandEventArgs e)
        {
            SpeakerFormView_UpdateItem(int.Parse(e.CommandArgument.ToString()));
        }



        protected void UpdateCancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/MembersOnly/Speakers.aspx");
        }


        public void SpeakerFormView_InsertItem()
        {
            var item = new LearningTreatz.Core.Speaker()
            {
                // RestaurantId = int.Parse(Request.QueryString["id"]),
                UserId = (Guid)Membership.GetUser().ProviderUserKey,
                Id = -1
            };

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                try
                {
                    item.SessionDescription = item.SessionDescription.Trim();
                    SpeakerService db = new SpeakerService();
                    db.Create(item, User);
                    Response.Redirect("~/MembersOnly/Speakers.aspx?id=" + item.Id, false);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Contents", ex.Message);
                }

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void SpeakerFormView_UpdateItem(int id)
        {
            SpeakerService db = new SpeakerService();
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            LearningTreatz.Core.Speaker item = db.SpeakerToEdit(id, User, userId);
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
                    item.SessionDescription = item.SessionDescription.Trim();
                    db.Update(item, User, userId);
                    Response.Redirect("~/MembersOnly/Speakers.aspx?id=" + item.Id, false);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Contents", ex.Message);
                }
            }
        }


        






    }
}