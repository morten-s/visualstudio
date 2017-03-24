using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryA.Models;
namespace MandatoryA.Infrastructure
{
    public class Repository
    {
        // added list employees for use in lookup
        private List<Employee> employees = new List<Employee>();
        public List<Employee> Employees { get { return employees; } }

        private List<Customer> customers = new List<Customer>();
        public List<Customer> Customers { get { return customers; } }
        // create dictionary collection for prices, and define property to get the collection
        private Dictionary<string, int> prices = new Dictionary<string, int>();
        public Dictionary<string, int> Prices { get { return prices; } }
        // create List with Reservations, and define property to get the List 
        private List<Reservation> reservations = new List<Reservation>();
        public List<Reservation> Reservations { get { return reservations; } }
        public Repository()
        {
            // add prices to the dictionary, prices 
            prices.Add("Dog", 200);
            prices.Add("Cat", 140);
            prices.Add("Snake", 120);
            prices.Add("Guinea pig", 75);
            prices.Add("Canary", 60);
            prices.Add("Bird spider", 90);
            prices.Add("Buggie", 70);
            prices.Add("Chinchilla", 70);
            prices.Add("Iguana", 160);
            prices.Add("Rabbit", 90);
            prices.Add("Great orca", 1660);
            prices.Add("White Shark", 760);
            prices.Add("Bullet Ant", 60);


            // create customers
            Customer c1 = new Customer("Susan", "Peterson", "Borgergade 45",
            "8000", "Aarhus", "supe@xmail.dk", "21212121");
            Customer c2 = new Customer("Brian", "Smith", "Algade 108",
            "8000", "Aarhus", "brsm@xmail.dk", "45454545");

            Employee e1 = new Employee("Helle", "Olsen", "HOL", "28282828");
            Employee e2 = new Employee("Maj", "Jensen", "MJN", "55555555");
            Employees.Add(e1);
            Employees.Add(e2);
            Customers.Add(c1);
            Customers.Add(c2);


            // added overloaded constructor with employee param , updates employee reservations
            Reservation r1 = new Reservation("Fido", "Dog",
            new DateTime(2014, 9, 2), new DateTime(2014, 9, 20), c1, e1);
            Reservation r2 = new Reservation("Samson", "Dog",
              new DateTime(2014, 9, 14), new DateTime(2014, 9, 21), c1, e1);
            Reservation r3 = new Reservation("Darla", "Cat",
              new DateTime(2014, 9, 7), new DateTime(2014, 9, 10), c2, e2);

            
        // add Reservations to list of Reservations with instance name reservations
            reservations.Add(r1); reservations.Add(r2); reservations.Add(r3);
        }
        
    }
}