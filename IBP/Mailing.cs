using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;
using System.Net;
using NUnit.Framework;

namespace IBP
{
    [TestClass]
    public class Mailing
    {
        [Test]
        public void MethodToSendEmail()
        {
            var fromAddress = new MailAddress("kaushl.singh07@gmail.com", "Kaushal");
            var toAddress = new MailAddress("crazyneeraj42@gmail.com", "To Name");
            const string fromPassword = "9300830154";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        //    //try
        //    {

        //        //Sender's email, Sender's Password, To/receiver's email, Subject, Body , CC, Attachment
        //        MailMessage mail = new MailMessage();
        //        string FromEmail = "k.f.kumar.singh@accenture.com";
        //        string Password = "Kks(07999";
        //        string ToEmail = "k.f.kumar.singh@accenture.com";
        //        string Subject = "Test Mail";
        //        string ContentBody = "<h3> Test mail from Selenium </h3>";
        //        mail.From = new MailAddress(FromEmail);
        //        mail.To.Add(ToEmail);
        //        mail.Subject = Subject;
        //        mail.Body = ContentBody;
        //        mail.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
        //        smtp.Credentials = new NetworkCredential(FromEmail, Password);
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);


        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    finally
        //    {
        //        Console.WriteLine("inside finally");
        //    }
        }
    }
}
