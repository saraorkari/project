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

        public bool SendMail(string type, string mailOrId, string productName)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                user user = db.users.FirstOrDefault(x => x.Id == mailOrId || x.Email == mailOrId);
                if (user == null)
                {
                    return false;
                }
                string body = "", subject = "";
                switch (type)
                {
                    case "update":
                        {
                            List<productInShop> g = db.productInShops.Where(x => x.product.Name.Contains(productName)).ToList();
                            subject = "עדכון על ירידת מחיר";
                            body = ReadFile(@"./html/update.html");
                            body = body.Replace("{productName}", productName);
                            string shopDetails = "", productDetails = "";
                            g.ForEach(x => { shopDetails += " שם: " + x.shop.Name + " מספר טלפון: " + x.shop.Phone + " איזור: " + x.shop.city.area.Name + " עיר: " + x.shop.city.Name; });
                            g.ForEach(x => { productDetails += " שם: " + x.product.Name + " תיאור: " + x.product.Description + " מחיר: " + x.Price + " תאריך ייצור: " + x.product.ProdDate + " תמונה: " + x.product.Picture; });
                            body = body.Replace("{shopDetails}", shopDetails);
                            body = body.Replace("{productDetails}", productDetails);
                            break;
                        }
                    case "askUpdate":
                        {
                            user.IsUpdate = true;
                            db.askUpdates.Add(new askUpdate() { UserId = user.Id, ProductId = db.products.FirstOrDefault(x => x.Name == productName).Id });
                            subject = "בקשתך לעדכון ירידת המחיר התקבלה";
                            body = ReadFile(@"C:\sara or\פרויקט גמר עם שרה אור\github\ask.txt");
                            body = body.Replace("{serchName}", productName); break;
                        }
                    case "password":
                        {
                            subject = "הסיסמא שלך";
                            body = ReadFile(@"C:\sara or\פרויקט גמר עם שרה אור\github\password.txt");
                            body = body.Replace("{password}", user.Password); break;
                        }
                }
                return send(user.Email, body, subject, "saraor1412@gmail.com");
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
        public bool send(string toMail, string body, string subject, string returnMail)
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
                return false;
            }
            return true;
        }
    }
}
