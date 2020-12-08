using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ADO.NET.Controllers
{
    public class HomeController : Controller
    {
        protected IUserRepository userRepository;

        public HomeController()
        {

        }
        public HomeController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hello in onlain version school journal";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            if (ModelState.IsValid)
            {
                User user = new User(email, password);

                User userInDB = this.userRepository.GetByEmail(email);
                if (userInDB != null && userInDB.password == user.password)
                {
                    userRepository.LogIn(userInDB.id);
                    if (userInDB.userRole == 1)
                    {
                        FormsAuthentication.SetAuthCookie(user.email, true);
                        return RedirectToAction("Index", "Student");
                    }                        
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.email, true);
                        return RedirectToAction("Index", "Teacher");
                    }
                        
                }
                else
                {
                    ModelState.AddModelError("400", "Неверный email или паполь!");
                }
            }
            return View();
        }
    }
}