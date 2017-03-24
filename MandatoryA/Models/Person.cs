using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MandatoryA.Models
{
    public class Person
    {
        //set in constructor - public readonly
        public int PersonID { get; set; }
        //read write
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Phone { get; set; }

        //Constructor
        public Person(int personID, string firstname, string lastname, string phone)
        {
            PersonID = personID;
            Firstname = firstname;
            Lastname = lastname;
            Phone = phone;
        }
        public Person()
        {

        }

    }
}