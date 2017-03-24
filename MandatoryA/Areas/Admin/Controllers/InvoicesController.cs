using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryA.Infrastructure;
using MandatoryA.Models;
using MandatoryA.Controllers;


namespace MandatoryA.Areas.Admin.Controllers
{
    public class InvoicesController : SessionController
    {
        // GET: Invoices
        public ActionResult Index()
        {
            return View(SessionRepository);
        }
        [HttpGet]
        public ActionResult Invoice(int? id)
        {
            if (id != null)
            {
                //Show all reservations
                //List<Reservation> customerReservations = SessionRepository.Reservations.FindAll(delegate (Reservation re) { return re.Customer.PersonID == id; });
                List<Reservation> customerReservations = SessionRepository.Reservations.FindAll(re=>re.Customer.PersonID == id );
                SessionRepository.Reservations[0].Customer.Firstname = "test";

                //Make selectlist with all customers - Linq dot notation
                SelectList customerList = new SelectList(SessionRepository.Reservations.Select(x => new { Name = x.Customer.Firstname + " " + x.Customer.Lastname, x.Customer.PersonID }).Distinct(), "PersonID", "Name");
                ViewBag.customerList = customerList;
                 
                // make a generic datatype, strongly typed
                Tuple<List<Reservation>, Repository> modelData = Tuple.Create(customerReservations, SessionRepository);

                return View(modelData);
            }
            return Content("No Content - No ID");
        }
    }
}