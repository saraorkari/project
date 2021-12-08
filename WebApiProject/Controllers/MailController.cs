using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiProject.Controllers
{
    [EnableCors(methods: "*", origins: "*", headers: "*")]
    public class MailController : ApiController
    {
        // GET api/mail
        MailService mailService = new MailService();
        public IHttpActionResult Get(string type, string mailOrId, string productName)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                MailService MailService = new MailService();
                user user = db.users.FirstOrDefault(x => x.Id == mailOrId || x.Email == mailOrId);
                if (user == null)
                {
                    return BadRequest("משתמש לא קיים - להרשמה->");
                }
                string body = "", subject = "", password = "";
                if (type == "update")
                {
                    List<productInShop> g = db.productInShops.Where(x => x.product.Name.Contains(productName)).ToList();
                    subject = "עדכון על ירידת מחיר";
                    body = MailService.ReadFile(@"C:\sara or\פרויקט גמר עם שרה אור\github\search.txt");
                    body = body.Replace("{serchName}", productName);
                    string content = "";
                    g.ForEach(x => { content += "<tr><td>" + x.product.Name + "</td><td>" + x.Price + "</td><td>" + x.shop.Name + "</td></tr>"; });
                    body = body.Replace("{content}", content);
                }
                else if (type == "password")
                {
                    subject = "הסיסמא שלך";
                    body = MailService.ReadFile(@"C:\sara or\פרויקט גמר עם שרה אור\github\password.txt");
                    body = body.Replace("{password}", user.Password);
                }
                string str = MailService.send(user.Email, body, subject, "saraor1412@gmail.com");
                if (str == "המייל נשלח בהצחלה")
                {
                    return Ok(str);
                }
                return BadRequest(str);
            }
        }

        // GET api/mail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}




