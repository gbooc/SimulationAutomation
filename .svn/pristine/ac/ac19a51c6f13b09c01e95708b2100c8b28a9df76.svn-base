using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Util
{
    public class Email
    {
        public static void SendApprovedFile(string fileAttachment, string to, string Cc)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("automailer.rimp@ph.ricoh-imaging.com");
           // mailMessage.To.Add("grace.booc@ph.ricoh-imaging.com"); //

            mailMessage.To.Add("e.racal@ph.ricoh-imaging.com"); //
            mailMessage.CC.Add("paul.barcoma@ph.ricoh-imaging.com,grace.booc@ph.ricoh-imaging.com");

            mailMessage.Subject = "Customer Order - " + DateTime.Today.ToString("yyyyMM");

            if(!string.IsNullOrEmpty(fileAttachment))
                mailMessage.Attachments.Add(new Attachment(fileAttachment));
            
            string headerMail = @"Hi All, <br>" + 
                                "Good day! <br><br>" +
                                "New customer order uploaded today, kindly refer the attached file.<br><br><br>";

            mailMessage.Body       = headerMail;
            mailMessage.IsBodyHtml = true;
            SmtpClient SmtpServer  = new SmtpClient();
            SmtpServer.Port = 25;
            SmtpServer.Host = "mail.ricoh.co.jp";
            SmtpServer.Send(mailMessage);
            mailMessage.Dispose();
        }
    }
}
