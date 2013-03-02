using System.Configuration;
using System.Net.Mail;


namespace LearningTreatz.Code
{
    public class EmailSender
    {
        public void sendEmail(string email,string message)
        {
            SmtpClient smtpclient = new SmtpClient(ConfigurationManager.AppSettings["MailServer"]);
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(ConfigurationManager.AppSettings["FromEmailAddress"]);
            mail.To.Add(email);
            mail.Subject = ConfigurationManager.AppSettings["FromEmailAddress"] + " is sending a message";
            //mail.Attachments.Add(new mail);
            mail.IsBodyHtml = true;
            mail.Body = message;
            smtpclient.Send(mail);

        }
    }
}