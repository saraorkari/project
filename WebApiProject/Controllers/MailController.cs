using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace WebApiProject.Controllers
{ }
    //public class MailController : ApiController
    //{
        //    // GET api/<controller>
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }

        //    // GET api/<controller>/5
        //    public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST api/<controller>
        //    public void Post([FromBody]string value)
        //    {
        //    }

        //    // PUT api/<controller>/5
        //    public void Put(int id, [FromBody]string value)
        //    {
        //    }

        //    // DELETE api/<controller>/5
        //    public void Delete(int id)
        //    {
        //    }

//        //יצירת אוביקט MailMessage
//        MailMessage mail = new MailMessage();

//        //למי לשלוח (יש אפשרות להוסיף כמה נמענים) 
//        mail.To.Add(“toEmailAddress”); 

//        //כתובת מייל לשלוח ממנה
//        mail.From = new MailAddress(“fromEmailAddress”);

//        // נושא ההודעה
//        mail.Subject = “mailSubject”; 

//        //תוכן ההודעה ב- HTML
//        mail.Body = “mailBody;”

//        //הגדרת תוכן ההודעה ל - HTML 
//        mail.IsBodyHtml = true; 

//        // Smtp יצירת אוביקט 
//        SmtpClient smtp = new SmtpClient();

//        //הגדרת השרת של גוגל
//        smtp.Host = "smtp.gmail.com";


//        //הגדרת פרטי הכניסה לחשבון גימייל
//        smtp.Credentials = new System.Net.NetworkCredential(
//		“myGmailEmailAddress @gmail.com", "myGmailPassword");
//        //אפשור SSL (חובה(
//        smtp.EnableSsl = true;
//        try
//        {
//            //שליחת ההודעה
//             smtp.Send(mail);
//        }   
//        catch (Exception ex)
//        {
//                //תפיסה וטיפול בשגיאות
//                txtMessage.Text = ex.ToString();
//        }
//    }

//}


