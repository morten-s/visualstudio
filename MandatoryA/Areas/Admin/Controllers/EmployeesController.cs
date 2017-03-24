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
    public class EmployeesController : SessionController
    {
        // GET: Admin/Employees
        public ActionResult Index()
        {
            
            return View(SessionRepository);
        }
        public ActionResult EditEmployee(int? id)
        {
            if (id != null)
            {
                Employee emp = (from s in SessionRepository.Employees where id == s.PersonID select s).Single();
                return View(emp);

            }
            else
            {
                return Content("No id");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(Employee emp)
        {
            //int emp = 0;
            if(emp != null)
            {
                // Find index of employee personid and replace
                int index = SessionRepository.Employees.FindIndex(x => x.PersonID == emp.PersonID);
                SessionRepository.Employees[index] = emp;
                return View("Index", SessionRepository);
            }
            else
            {
                return Content("No employee");
            }
        }
        public ActionResult CreateEmployee()
        {
            // employee empty constructor doesnt update personid
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            // make an employee with person id autonum set in this employee constructor
           Employee employee = new Employee(emp.Firstname, emp.Lastname, emp.Initials, emp.Phone);
            // update employees list
            SessionRepository.Employees.Add(employee);
            return View("Index", SessionRepository);
        }
        public ActionResult DeleteEmployee(int? id)
        {
            if (id != null)
            {
                return View(SessionRepository.Employees.Single(x => x.PersonID == id));
            }
            else
            {
                return Content("No employee");
            }
            // employee empty constructor doesnt update personid
        }
        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            if (id != null)
            {
                // Find index of employee personid and delete
                int index = SessionRepository.Employees.FindIndex(x => x.PersonID == id);
                SessionRepository.Employees.RemoveAt(index);
                return View("Index", SessionRepository);
            }
            else
            {
                return Content("No employee");
            }
        }

    }

}
