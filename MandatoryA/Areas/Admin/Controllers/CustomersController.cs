using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryA.Infrastructure;
using MandatoryA.Controllers;
using MandatoryA.Models;

namespace MandatoryA.Areas.Admin.Controllers
{
    public class CustomersController : SessionController
    {
        // GET: Admin/Customers
        public ActionResult Index()
        {
            return View(SessionRepository);
        }
    }
}