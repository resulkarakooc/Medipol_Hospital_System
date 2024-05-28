using MimeKit;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Medipol_Hospital.MailService
{
    public static class MailService
    {
        public static void SendEmail(string recipientEmail,int rnd)
        {
            try
            {
                string smtpServer = "smtp.gmail.com"; //SMTP sunucusu adresi
                int port = 587; //SMTP sunucusu port numarası
                string senderEmail = "resul.krkoc@gmail.com"; //Gönderen e-posta adresi
                string password = "ecugpjsuhqbrvnwy"; //Gönderen e-posta hesabının şifresi gerçek şifre değil

                MailMessage mail = new MailMessage();  
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = "Medipol Hastanesi Onay Kodu"; //E-posta konusu
                mail.Body = "Hesabınıza giriş yapmak için onay kodunuz :" + rnd; //E-posta içeriği

                SmtpClient smtpClient = new SmtpClient(smtpServer, port); //protokolü oluştur
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, password);
                smtpClient.EnableSsl = true; //güvenliği aç

                smtpClient.Send(mail); //gönder
                MessageBox.Show("E-Posta gönderildi");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderirken bir hata oluştu: " + ex.Message);
            }

        }
    }
}
