using System;
using System.Net;
using System.Net.Mail;
using DBackup.Service.Contract;

namespace DBackup.Service.Concrete
{
    public class EmailService : IEMailService
    {
        public void SendReport(string reportDetails)
        {
            try
            {
                var client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("eposta adresi", "parola");

                string fromAddress = "gönderen adres";
                string toAddress = "alıcı adress";

                using (var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Body = reportDetails,
                    Subject = $"{DateTime.Now} tarihli DBackup Sonuç Raporu",
                    IsBodyHtml = true
                })
                {
                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Smtp exception message: {ex.Message}");
                
                throw;
            }
        }
    }
}