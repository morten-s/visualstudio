using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MandatoryA.Models
{
    public class Customer : Person
    {
        static int idCounter = 1;

        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public Customer(string firstname, string lastname, string address, string zipcode, string city, string email, string phone) : base(idCounter, firstname, lastname, phone)
        {
            Address = address;
            Zipcode = zipcode;
            Email = email;
            City = city;
            idCounter++;
        }
        public Customer()
        {
        }

    }
}