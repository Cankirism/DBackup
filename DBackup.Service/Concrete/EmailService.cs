using DBackup.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
                    Subject = $"{DateTime.Now.ToString()} tarihli DBackup Sonuç Raporu ",
                    IsBodyHtml = true
                })
                {
                    client.Send(mailMessage);
                }
            }

            catch (Exception)
            {

                throw;
            }

        }
    }

}