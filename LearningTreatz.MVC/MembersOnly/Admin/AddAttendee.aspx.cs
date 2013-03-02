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
    public partial class AddAttendee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["Id"] != null)
            {
                this.AttendeeFormView.DefaultMode = FormViewMode.Edit;
            }

        }





        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public LearningTreatz.Core.Attendee AttendeeFormView_GetItem()
        {
            AttendeeService db = new AttendeeService();
            return db.AttendeeToEdit(int.Parse(Request.QueryString["Id"].ToString()),
                                   User,
                                   (Guid)Membership.GetUser().ProviderUserKey);

        }


         protected void InsertButton_Command(object sender, CommandEventArgs e)
        {
            AttendeeFormView_InsertItem();
        }



        protected void UpdateButton_Command(object sender, CommandEventArgs e)
        {
            AttendeeFormView_UpdateItem(int.Parse(e.CommandArgument.ToString()));
        }



        protected void UpdateCancelButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/MembersOnly/Admin/ExpectedAttendees.aspx");
        }


        public void AttendeeFormView_InsertItem()
        {
            var item = new LearningTreatz.Core.Attendee()
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
                    
                    AttendeeService db = new AttendeeService();
                    db.Create(item, User);
                    Response.Redirect("~/MembersOnly/Admin/ExpectedAttendees.aspx?id=" + item.Id, false);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Contents", ex.Message);
                }

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AttendeeFormView_UpdateItem(int id)
        {
            AttendeeService db = new AttendeeService();
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            LearningTreatz.Core.Attendee item = db.AttendeeToEdit(id, User, userId);
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
                    
                    db.Update(item, User, userId);
                    Response.Redirect("~/MembersOnly/Admin/ExpectedAttendees.aspx?id=" + item.Id, false);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Contents", ex.Message);
                }
            }
        }


        






    }
}