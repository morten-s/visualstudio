using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MandatoryA.Models
{
    public class Employee : Person
    {
        static int idCounter = 1;

//        List<Reservation> reservations = new List<Reservation>();
        // read only property outside class set in constructor
        [Required]public string Initials { get; set; }
//        public List<Reservation> Reservations { get { return reservations; } }

        // Constructor
        public Employee(string firstname, string lastname,  string initials, string phone) : base(idCounter, firstname, lastname, phone)
        {
            Initials = initials;
            idCounter++;
        }
        public Employee()
        {
            
        }


  /*      public void AddReservation( Reservation reservation)
        {
            reservations.Add(reservation);
        }
    */
    }
}