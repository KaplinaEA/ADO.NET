using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO.NET.Controllers
{
    public class TeacherController : Controller
    {
        protected IUserRepository userRepository;
        protected ITeacherRepository teacherRepository;

        public TeacherController()
        {

        }
        public TeacherController(
            IUserRepository userRepository,
            ITeacherRepository teacherRepository
            )
        {
            this.userRepository = userRepository;
            this.teacherRepository = teacherRepository;
        }
        [Authorize]
        public ActionResult Index(int Id)
        {
            ViewData["Id"] = Id;
            return View();
        }
        [Authorize]
        new public ActionResult Profile(int Id)
        {
            ViewData["Id"] = Id;
            return View(this.teacherRepository.Show(Id));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewData["Id"] = Id;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(DateTime DateOfBirth, int experience, int Id)
        {
            ViewData["Id"] = Id;
            if (ModelState.IsValid)
            { 
                this.teacherRepository.Edit(Id, DateOfBirth, experience);
                 return RedirectToAction("Index", "Teacher", new { Id = Id });
            }

            return View();
        }
    }
}