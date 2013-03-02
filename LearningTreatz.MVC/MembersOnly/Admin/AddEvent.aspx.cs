using LearningTreatz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningTreatz.MembersOnly.Admin
{
    public partial class AddEvent : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["Id"] != null)
            {
                this.EventFormView.DefaultMode = FormViewMode.Edit;
            }

        }





        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public LearningTreatz.Core.Event EventFormView_GetItem()
        {
            EventService db = new EventService();
            return db.EventToEdit(int.Parse(Request.QueryString["Id"].ToString()),
                                   User,
                                   (Guid)Membership.GetUser().ProviderUserKey);

        }


        protected void InsertButton_Command(object sender, CommandEventArgs e)
        {
            EventFormView_InsertItem();
        }



        protected void UpdateButton_Command(object sender, CommandEventArgs e)
        {
            EventFormView_UpdateItem(int.Parse(e.CommandArgument.ToString()));
        }



        protected void UpdateCancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/MembersOnly/Admin/Events.aspx");
        }


        public void EventFormView_InsertItem()
        {
            var item = new LearningTreatz.Core.Event()
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

                    string updatedString = string.Empty;
                    CheckBoxList c = (CheckBoxList)EventFormView.FindControl("SpeakerAVRequirementsCheckBoxList");
                    for (int i = 0; i < c.Items.Count; i++)
                    {
                        if (c.Items[i].Selected == true)
                        {
                            updatedString += c.Items[i].Value + ",";
                        }
                    }
                    item.SpeakerAVRequirements = updatedString.TrimEnd(',');




                    EventService db = new EventService();
                    db.Create(item, User);
                    Response.Redirect("~/MembersOnly/Admin/Events.aspx?id=" + item.Id, false);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Contents", ex.Message);
                }

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void EventFormView_UpdateItem(int id)
        {
            EventService db = new EventService();
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            LearningTreatz.Core.Event item = db.EventToEdit(id, User, userId);
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



                    string updatedString = string.Empty;
                    CheckBoxList c = (CheckBoxList)EventFormView.FindControl("SpeakerAVRequirementsCheckBoxList");
                    for (int i = 0; i < c.Items.Count; i++)
                    {
                        if (c.Items[i].Selected == true)
                        {
                            updatedString += c.Items[i].Value + ",";
                        }
                    }
                    item.SpeakerAVRequirements = updatedString.TrimEnd(',');




                    db.Update(item, User, userId);
                    Response.Redirect("~/MembersOnly/Admin/Events.aspx?id=" + item.Id, false);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Contents", ex.Message);
                }
            }
        }

        protected void EventFormView_DataBound(object sender, EventArgs e)
        {
            if (EventFormView.CurrentMode == FormViewMode.Edit)
            {
                CheckBoxList c = (CheckBoxList)this.EventFormView.FindControl("SpeakerAVRequirementsCheckBoxList");

                Label s = (Label)this.EventFormView.FindControl("SpeakerAVRequirementsLabel");


                string[] items = s.Text.Split(',');


                for (int i = 0; i < c.Items.Count; i++)
                {
                    if (items.Contains(c.Items[i].Value))
                    {
                        c.Items[i].Selected = true;
                    }
                }
            }
        }









    }
}