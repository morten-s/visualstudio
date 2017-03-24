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
    public class ReservationsController : SessionController
    {
        // GET: reservations
        public ActionResult Index()
        {
            return View(SessionRepository);
        }

        
        public ActionResult CreateReservation()
        {
            // best solution for posting data from forms
            //ViewmodelReservation vm = new ViewmodelReservation{ Repository = SessionRepository };
            ViewBag.employeesList = new SelectList(from s in SessionRepository.Employees select new { PersonID = s.PersonID, Name = s.Firstname + " " + s.Lastname }, "PersonID", "Name");

            ViewBag.specieList = new SelectList( SessionRepository.Prices, "Key","Key");

            ViewBag.prices = SessionRepository.Prices;
            return View(new Reservation());
            //return View(Tuple.Create(new Reservation(),SessionRepository, new Customer()));
        }
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult CreateReservation(Reservation res)
        {
            //return Content(res.ToString());
            res.Employee = (Employee)(from s in SessionRepository.Employees where s.PersonID == res.EmployeeID select s).Single();
            res.Customer = SessionRepository.Customers[0];
            SessionRepository.Reservations.Add(res);
            return View("Index", SessionRepository);
        }

    }
}