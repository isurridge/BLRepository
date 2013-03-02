using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using LearningTreatz.Code;
using LearningTreatz.Services;
using System.Security.Principal;
using System.Web.Security;


namespace LearningTreatz.MembersOnly
{
    public partial class Speakers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_Init()
        {
            UserIdFilter.Value = StateManager.EmailAddress;
            UserIdFilter.DataBind();
            
        }



   
        
       /// <summary>
       /// Collecting the selected speaker and co-presenter and sending them a message
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void btnRetrieveCheck_Click(object sender, EventArgs e)
        {

            SpeakerService db = new SpeakerService();
            string r = "";
            EmailSender sndEmail = new EmailSender();

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("chkSelect");
                int RowIndex = row.RowIndex;
                int ID = (int)GridView1.DataKeys[RowIndex].Value;

                r = row.Cells[7].Text; //grabbing email address from emailaddress column

                if (cb.Checked == true)
                {
                    string[] email = (string[])db.emailLKup(r);

                    for (int i = 0; i < email.Length; i++)
                    {
                        sndEmail.sendEmail(email[i].ToString(), MessageTextBox.Text);
                        lblMessage.Text = "Your email was sent: " + (i + 1);
                    }
                }
            }
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
                e.Row.Cells[2].Attributes.Add("onclick", "location='/MembersOnly/AddSpeaker.aspx?id=" + e.Row.Cells[0].Text + "'");
            }
        }





        protected void AddSpeakerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MembersOnly/AddSpeaker.aspx", false);

        }




        // The id parameter name should match the DataKeyNames value set on the control
        public void DeleteSpeaker(int id)
        {
            SpeakerService db = new SpeakerService();
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            LearningTreatz.Core.Speaker item = db.SpeakerToEdit(id, User, userId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);

                // Save changes here, e.g. MyDataLayer.SaveChanges();
                try
                {
                    db.Delete(item, User, userId);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
            
        }





        protected void DeleteButton_Command(object sender, CommandEventArgs e)
        {

            SpeakerService db = new SpeakerService();

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("chkSelect");
                int RowIndex = row.RowIndex;
                int ID = (int)GridView1.DataKeys[RowIndex].Value;

                if (cb.Checked == true)
                {
                    DeleteSpeaker(ID);
                }
            }
            Response.Redirect("~/MembersOnly/SpeakerPortal.aspx");
        }






    }
}