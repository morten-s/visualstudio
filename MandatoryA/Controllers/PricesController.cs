﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryA.Infrastructure;

namespace MandatoryA.Controllers
{
    public class PricesController : SessionController
    {
        // GET: Prices
        public ActionResult Index()
        {
            return View("_Pricelist", SessionRepository);
        }
    }
}