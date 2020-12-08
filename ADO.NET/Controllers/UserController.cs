using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO.NET.Controllers
{
    public class UserController : Controller
    {
        protected IUserRepository userRepository;

        public UserController()
        {

        }
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateNewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNewUser(string email, string userName, string password, int role)
        {
            ViewBag.Message = "Регистрация";

            if (ModelState.IsValid)
            {
                int count = this.userRepository.List().Count();
                User user = new User(email, userName, password, role, ++count);

                this.userRepository.New(user);
                User userInDB = this.userRepository.GetByEmail(email);                

                if (userInDB != null)
                {
                    return RedirectToAction("SignIn", "Home");                  
                }
                else
                {
                    ModelState.AddModelError("400", "Ошибка при регистрации.");
                }
            }

            return View();
        }
    }
}