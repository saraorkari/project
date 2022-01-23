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
        public string Get(string type, string mailOrId, string productName)
        {
            string errMsg;
            mailService.SendMail(type, mailOrId, productName, out errMsg);
            return errMsg;
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




