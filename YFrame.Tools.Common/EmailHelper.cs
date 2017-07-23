using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Tools.Common
{
    public class EmailHelper
    {
        public static void SendEmail(EmailModel model)
        {
            string SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            string SendEmail = ConfigurationManager.AppSettings["SendEmail"];
            string SendEmailPwd = ConfigurationManager.AppSettings["SendEmailPwd"];
            if (string.IsNullOrEmpty(SmtpHost) || string.IsNullOrEmpty(SendEmail) || string.IsNullOrEmpty(SendEmailPwd)) throw new Exception("请配置邮箱信息");
            int SendCount = ConfigurationManager.AppSettings["SendCount"].ToInt32();

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SendEmail);
            mail.To.Add(model.Recipients);

            mail.IsBodyHtml = true;
            mail.Subject = model.Title;
            mail.Body = model.Content;

            mail.SubjectEncoding = Encoding.Default;
            mail.BodyEncoding = Encoding.Default;
            SmtpClient smtp = new SmtpClient(SmtpHost);
            smtp.Credentials = new NetworkCredential(SendEmail, SendEmailPwd);
            smtp.Send(mail);
            mail.Dispose();
        }
    }

    public class EmailModel
    {
        /// <summary>
        /// 收件人邮箱地址
        /// </summary>
        public string Recipients { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content { get; set; }
    }
}
