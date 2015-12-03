namespace YekanPedia.EmailGateway.Proxy.Services
{
    using Model;
    using System.Net.Mail;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Web;
    using System;
    using ManagementSystem.InfraStructure.Date;
    using Service.Interfaces;

    public class EmailGateway : IEmailGateway
    {
        readonly IAboutUsService _aboutUsService;
        public EmailGateway(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        const string smtpAddress = "mail.yekanpedia.org";
        const int portNumber = 25;
        const bool enableSSL = false;
        const string emailFrom = "support@yekanpedia.org";
        const string password = "sp123!@#";

        public void SendSimpleEmail(EmailModel model)
        {
            var aboutUs = _aboutUsService.GetAboutUsInfo();
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(aboutUs?.Email);
                foreach (var item in model.EmailAddress)
                {
                    mail.To.Add(item);
                }
                mail.BodyEncoding = Encoding.GetEncoding("utf-8");
                mail.Subject = model.Subject;
                using (var reader = File.OpenText(HttpContext.Current.Server.MapPath("~/Templates/Simple.html")))
                {
                    var body = reader.ReadToEnd();
                    body = body.Replace("{{Text}}", model.Body)
                               .Replace("{{Email}}", aboutUs?.Email)
                               .Replace("{{Year}}", DateTime.Now.Year.ToString())
                               .Replace("{{DateTime}}", PersianDateTime.Now.ToString(PersianDateTimeFormat.FullDate))
                               .Replace("{{Telephone}}", aboutUs?.Telphone)
                               .Replace("{{Address}}", aboutUs?.Address)
                               .Replace("{{GooglePlus}}", aboutUs?.GooglePlus)
                               .Replace("{{Facebook}}", aboutUs?.Facebook)
                               .Replace("{{LinkedIn}}", aboutUs?.LinkedIn)
                               .Replace("{{Twitter}}", aboutUs?.Twitter)
                               .Replace("{{Telegram}}", aboutUs?.Telegram)                               ;
                    AlternateView plainView = AlternateView.CreateAlternateViewFromString(Regex.Replace(body, @"<(.|\n)*?>", string.Empty), null, "text/plain");
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    mail.AlternateViews.Add(plainView);
                    mail.AlternateViews.Add(htmlView);
                    mail.Body = body;
                }
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}
