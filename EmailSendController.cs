using SimpleEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleEmailApp.Controllers
{
    public class EmailSendController : ApiController
    {
        [Route("api/EmailSend")]
        [HttpPost]
        public IAsyncResult SendEmail(string bodyHTML, string Subject, string Emails)
        {
            bool fp = GernalFunction.EmailSent(bodyHTML, Subject, Emails);
            return (IAsyncResult)Ok(fp);
        }
    }
}
