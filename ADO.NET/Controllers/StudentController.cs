using ADO.NET.Models;
using AutoMapper;
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
        [Authorize]
        public ActionResult Index(int Id)
        {
            System.Diagnostics.Debug.WriteLine(Id + " Index");
            ViewData["Id"] = Id;
            return View();
        }
        [Authorize]
        new public ActionResult Profile(int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>());
            var mapper = new Mapper(config);
            var student = mapper.Map<StudentModel>(studentRepository.Show(Id));

            ViewData["Id"] = Id;
            return View(student);
        }
        [Authorize]
        [HttpGet]
        public ActionResult GetJournal(int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Journal, JournalModel>());
            var mapper = new Mapper(config);
            var journal = mapper.Map<List<JournalModel>>(this.studentRepository.GetJournal(Id));

            ViewData["Id"] = Id;            
            return View(journal);
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
        public ActionResult Edit(DateTime DateOfBirth, string studentClass, int Id)
        {
            System.Diagnostics.Debug.WriteLine(Id + " Edit2");
            ViewData["Id"] = Id;
            if (ModelState.IsValid)
            {
                this.studentRepository.Edit(Id, DateOfBirth, studentClass);

                return RedirectToAction("Index", "Student", new { Id = Id });
            }
            

            return View();
        }
    }
}