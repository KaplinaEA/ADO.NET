using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ADO.NET.Controllers
{
    public class StudentController : Controller
    {
        protected IUserRepository userRepository;
        protected IStudentRepository studentRepository;

        public StudentController()
        {

        }
        public StudentController(
            IUserRepository userRepository, 
            IStudentRepository studentRepository 
            )
        {
            this.userRepository = userRepository;
            this.studentRepository = studentRepository;
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {            
            return View(this.studentRepository.Show(userRepository.GetByEmail(User.Identity.Name).id));
        }
        public ActionResult GetJournal()
        {
            return View();
        }
           
        public ActionResult Edit()
        {
            return View();
        }
        
    }
}