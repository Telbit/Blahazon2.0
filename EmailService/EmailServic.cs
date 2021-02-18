using Blahazon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Blahazon.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Blahazon.EmailService
{
    public class EmailServic : IEmailService
    {
        private string adminEmail;
        private string adminPassword;
        private SmtpClient smtpClient;
        IConfiguration Config { get; }

        public EmailServic(IConfiguration configuration)
        {
            Config = configuration;
            adminEmail = Config.GetValue<string>("AdminEmail:EmailAddress");
            adminPassword = Config.GetValue<string>("AdminEmail:EmailPassword");
            Setup(adminEmail, adminPassword);
        }
        public void SendRecipt(string userEmail, List<OrderItem> products)
        {
            StringBuilder messageBody = new StringBuilder();
            string head = "Thank you for your Order!\nORDER CONFIRMATION:  \n";

            messageBody.Append(head).AppendLine();
            messageBody.Append("Product:                            Quantity:                           Total Price:");
            foreach (var item in products)
            {
                messageBody.Append("\n"+item.ProductTitle + "                       "+item.Quantity +"                      "+item.TotalPrice);
                //messageBody.Append("\nProduct name: " + item.ProductTitle + "    Quantity: " + item.Quantity + "    Total Price: " + item.TotalPrice);
            }
            messageBody.Append("\nKöszi gyere máskor is.");

            try
            {
                MailMessage messageObj = new MailMessage();
                messageObj.To.Add("divixed12@gmail.com");
                messageObj.From = new MailAddress(adminEmail);
                messageObj.Subject = "Order confirmation";
                messageObj.Body = messageBody.ToString();

                smtpClient.Send(messageObj);

            }
            catch (Exception ex)
            {
                Logger.GetNewEventLog().WriteEntry("Email service setup failed : " + ex, EventLogEntryType.Error, 1, (short)Logger.LogTypes.EmailSendingFailed);
            }
        }

        public void Setup(string adminEmail, string adminPassword)
        {
            this.adminPassword = adminPassword;
            this.adminEmail = adminEmail;

            try
            {
                smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(adminEmail, adminPassword);
                smtpClient.EnableSsl = true;

            }
            catch (Exception ex)
            {
                Logger.GetNewEventLog().WriteEntry("Email service setup failed : " + ex, EventLogEntryType.Error, 2, (short)Logger.LogTypes.EmailServiceSetupFailed);
            }
        }
    }
}
