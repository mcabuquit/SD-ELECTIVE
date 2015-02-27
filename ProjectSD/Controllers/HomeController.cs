using ProjectSD.DAL;
using ProjectSD.Models;
using ProjectSD.MySession;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSD.Controllers
{
    public class HomeController : Controller
    {
        public MyDatabaseContext db=new MyDatabaseContext();

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
            try {
                if (ModelState.IsValid)
                {
                    var result=db.Users.Where(u=>u.Username==user.Username && u.Password==user.Password).Count();
                    if(result>0){
                        var usr = db.Users.Where(u => u.Username == user.Username && u.Password == user.Password).SingleOrDefault();
                        //goes to session
                        MyOwnSession.getInstance().user =usr;

                        //if success
                        if (user.Username.Equals("admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Member");
                        }
                    }  
                }
            }catch(DataException){
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
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
            try { 
                if(ModelState.IsValid){
                    Users u = new Users()
                    {
                        Username=user.Username,
                        Password=user.Password
                    };
                    db.Users.Add(u);
                    db.SaveChanges();


                    PersonalInfo p = new PersonalInfo()
                    {
                        Name=user.Name,
                        UserID=u.UsersID
                    };
                    db.PersonalInfo.Add(p);
                    db.SaveChanges();
                    return Redirect("Login");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            
            return View();
        }
    }
}
