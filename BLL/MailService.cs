using DAL;
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

        public bool SendMail(string type, string mailOrId, string productName, out string errMsg)
        {
            errMsg = "";
            using (dbprojectEntities db = new dbprojectEntities())
            {
                user user = db.users.FirstOrDefault(x => x.Id == mailOrId || x.Email == mailOrId);
                if (user == null)
                {
                    errMsg = "פרטי המשתמש לא קיימים במערכת, נסה שנית או הירשם";
                    return false;
                }
                string body = "", subject = "";
                switch (type)
                {
                    case "askUpdate":
                        {
                            user.IsUpdate = true;
                            askUpdate askUpdate = new askUpdate() { UserId = user.Id, ProductId = db.products.FirstOrDefault(x => x.Name == productName).Id };
                            db.askUpdates.Add(askUpdate);
                            db.SaveChanges();
                            subject = "בקשתך לעדכון ירידת המחיר התקבלה";
                            body = ReadFile(@"C:/sara or/פרויקט גמר עם שרה אור/github/project/WebApiProject/mail/ask.txt");
                            body = body.Replace("{serchName}", productName); break;
                        }
                    case "password":
                        {
                            subject = "הסיסמא שלך";
                            //body = ReadFile(@"./html/password.html");
                            body = ReadFile(@"C:/sara or/פרויקט גמר עם שרה אור/github/project/WebApiProject/mail/password.txt");

                            body = body.Replace("{password}", user.Password); break;
                        }
                }
                return send(user.Email, body, subject, "saraor1412@gmail.com",out errMsg);
            }
        }

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
        public bool send(string toMail, string body, string subject, string returnMail, out string errMsg)
        {
            MailMessage mail = new MailMessage();
            //למי לשלוח (יש אפשרות להוסיף כמה נמענים) 
            mail.To.Add(toMail);
            mail.ReplyToList.Add(returnMail);
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
                errMsg = ex.Message;
                return false;
            }
            errMsg = "המייל נשלח בהצלחה!!!";
            return true;
        }
    }
}
