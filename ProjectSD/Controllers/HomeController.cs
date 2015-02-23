using ProjectSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        //GET : Home/Login
        public ActionResult Login() {
            return View();
        }

       //POST: Home/Login
        [HttpPost]
        public ActionResult Login(Users user) 
        {
            if (ModelState.IsValid)
            {
                return View();
            }
         
            return View();
        }

        //GET: Home/Registration
        public ActionResult Registration() {
            return View();
        }

        //POST: Home/Registration
        [HttpPost]
        public ActionResult Registration(Registration user) { 
            if(ModelState.IsValid){
                return View();
            }
            return View();
        }




    }
}
