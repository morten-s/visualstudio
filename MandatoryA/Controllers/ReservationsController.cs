using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryA.Infrastructure;
using MandatoryA.Models;

namespace MandatoryA.Controllers
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

        // CSRF 
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult CreateReservation(Reservation res)
        {
            // update employee to personid and create customer from form
            res.Employee = (Employee)(from s in SessionRepository.Employees where s.PersonID == res.EmployeeID select s).Single();
            res.Customer = new Customer(res.Firstname,res.Lastname,res.Address,res.Zipcode,res.City, res.Email, res.Phone);
            // add reservation and customer to sessionrepository
            SessionRepository.Reservations.Add(res);
            SessionRepository.Customers.Add(res.Customer);
            return View("Reservation", Tuple.Create(res, SessionRepository));
        }

    }
}