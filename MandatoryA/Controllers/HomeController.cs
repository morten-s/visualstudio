using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MandatoryA.Controllers
{
    public class HomeController : SessionController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(SessionRepository);
        }
    }
}