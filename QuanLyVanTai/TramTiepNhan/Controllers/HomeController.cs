using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace TramTiepNhan.Controllers
{
    [RoutePrefix("~")]
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "Wrong way???";
        }

        [Route("~/Ping")]
        [HttpGet]
        public string Ping ()
        {
            return DateTime.Now.ToString();
        }
    }
}
