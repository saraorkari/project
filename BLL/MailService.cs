using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MailService
    {
        public string ReadFile(string path)
        {
            string fullPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
            FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            StreamReader reader;
            using (reader = new StreamReader(fs))
            {
                return reader.ReadToEnd();
            }
        }
        public void send(string toMail, string body, string subject, string returnMail)
        {
            MailMessage mail = new MailMessage();
            //למי לשלוח (יש אפשרות להוסיף כמה נמענים) 
            mail.To.Add(toMail);
            //mail.ReplyToList.Add(returnMail);
            //כתובת מייל לשלוח ממנה
            mail.From = new MailAddress("pro1ject2@gmail.com");

            // נושא ההודעה
            mail.Subject = subject;

            //תוכן ההודעה ב- HTML
            mail.Body = body;

            //הגדרת תוכן ההודעה ל - HTML 
            mail.IsBodyHtml = true;

            // Smtp יצירת אוביקט 
            SmtpClient smtp = new SmtpClient();

            //הגדרת השרת של גוגל
            smtp.Host = "smtp.gmail.com";


            //הגדרת פרטי הכניסה לחשבון גימייל
            smtp.Credentials = new System.Net.NetworkCredential("pro1ject2@gmail.com", "project10!");
            //אפשור SSL (חובה(
            smtp.EnableSsl = true;
            try
            {
                //שליחת ההודעה
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
