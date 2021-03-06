﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebStore.WebApplication.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await Task.Run(() =>
            {
                var fromAddress = new MailAddress("***", "***");
                var toAddress = new MailAddress(email);
                const string fromPassword = "***";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = htmlMessage
                })
                {
                    smtp.Send(message);
                }
            });

        }
    }
}








//using System.Net;
//using System.Net.Mail;
//using System.Threading.Tasks;

//namespace GoogleShopping.WebApplication.Services
//{
//    // This class is used by the application to send email for account confirmation and password reset.
//    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
//    public class EmailSender : IEmailSender
//    {

//        public void SendEmail(string email, string subject, string bodyMessage)
//        {
//            var fromAddress = new MailAddress("robert.petlak@it-develop.pl", "BaseBox");
//            var toAddress = new MailAddress(email);
//            using (var client = new SmtpClient("192.168.160.50", 25))
//            {
//                var mailMessage = new MailMessage
//                {
//                    //IsBodyHtml = true,
//                    Body = bodyMessage,
//                    From = fromAddress,
//                    Subject = subject
//                };
//                mailMessage.To.Add(toAddress);
//                client.Send(mailMessage);
//            }



//        }
//    }
//}
