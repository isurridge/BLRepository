using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningTreatz
{
    public partial class Contact : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MailMessage m = new MailMessage(FromTextBox.Text,
                                                ConfigurationManager.AppSettings["ToEmailAddress"],
                                                SubjectTextBox.Text,
                                                BodyTextBox.Text);
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["MailServer"]);
                client.Send(m);
                Response.Redirect("~/ThankYou.aspx");
            }
        }
    }
}