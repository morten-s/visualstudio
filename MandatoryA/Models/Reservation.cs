using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MandatoryA.Models
{
    public class Reservation
    {
        static int idCounter = 1;

        //could use readonly field instead
        //public readonly int reservationId;
        // set in contstructor public readonly property
        public int ReservationID {get; private set;}
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Email { get; set; }
        // auto get setters
        [Required]
        public string Petname { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Specie { get; set; }

        [Required][DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        // set in contstructor public readonly property
        public Customer Customer { get;  set; }

        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }

        public Reservation(string petName, string specie, DateTime startDate, DateTime endDate, Customer customer)
        {
            //this.reservationId = reservationID;
            ReservationID = idCounter++;
            Petname = petName;
            Specie = specie;
            StartDate = startDate;
            EndDate = endDate;
            Customer = customer;
            CustomerID = customer.PersonID;
        }
        public Reservation(string petName, string specie, DateTime startDate, DateTime endDate, Customer customer, Employee employee)
        {
            //this.reservationId = reservationID;
            ReservationID = idCounter++;
            Petname = petName;
            Specie = specie;
            StartDate = startDate;
            EndDate = endDate;
            CustomerID = customer.PersonID;
            EmployeeID = employee.PersonID;
            Employee = employee;
            Customer = customer;
//removed            employee.AddReservation(this);
        }
        public Reservation() {
        }
    }
}