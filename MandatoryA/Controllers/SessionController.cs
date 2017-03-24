using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MandatoryA.Infrastructure;
namespace MandatoryA.Controllers
{
    //holds common functions, as session controle
    public class SessionController : Controller
    {
        private Repository repository;
        public Repository SessionRepository{ get { return repository; } }

        //
        public void SaveSessionRepository()
        {
            System.Web.HttpContext.Current.Session["repository"] = repository;
        }
        
        //decstructor
        ~SessionController()
        {
            System.Web.HttpContext.Current.Session["repository"] = repository;
        }
        //constructor
        public SessionController()
        {
            
            if (System.Web.HttpContext.Current.Session["repository"] == null)
            {
                repository = new Repository();
                System.Web.HttpContext.Current.Session["repository"] = repository;
            }
            else
            {
                repository = (Repository)System.Web.HttpContext.Current.Session["repository"];
            }

        }
    }
}