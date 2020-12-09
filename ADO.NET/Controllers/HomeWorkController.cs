using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO.NET.Controllers
{
    public class HomeWorkController : Controller
    {
        protected IHomeworkRepository homeworkRepository;
        protected IUserRepository userRepository;

        public HomeWorkController()
        {

        }
        public HomeWorkController(
            IHomeworkRepository homeworkRepository,
            IUserRepository userRepository
            )
        {
            this.homeworkRepository = homeworkRepository;
            this.userRepository = userRepository;
        }
        // GET: HomeWork
        public ActionResult Index(int IdUser)
        {
            ViewData["IdUser"] = IdUser;
            return View(homeworkRepository.List());
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create(int IdUser)
        {
            ViewData["IdUser"] = IdUser;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(string name, int IdUser, string text = "")
        {
            if (ModelState.IsValid)
            {
                int count = this.homeworkRepository.List().Count();

                homeworkRepository.New(new Entities.Homework(++count, name, text));
                return RedirectToAction("Index", "HomeWork", new { IdUser = @ViewData["IdUser"] });
            }
            ViewData["IdUser"] = IdUser;
            return View();
        }


        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id, int IdUser)
        {
            ViewData["IdUser"] = IdUser;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(string name, string text, int id, int IdUser)
        {
            ViewData["IdUser"] = IdUser;
            if (ModelState.IsValid)
            {
                this.homeworkRepository.Edit(id, name, text);
                return RedirectToAction("Index", "HomeWork", new { IdUser = IdUser });
            }

            return View();
        }

        public ActionResult Delete(int id, int IdUser)
        {
            homeworkRepository.Delete(id);
            return RedirectToAction("Index", "HomeWork", new { IdUser = IdUser });
        }

        public ActionResult Details(int id, int IdUser)
        {
            @ViewData["id"] = id;
            ViewData["IdUser"] = IdUser;
            return View(this.homeworkRepository.Show(id));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Assign(int id, int IdUser)
        {
            SelectList u = new SelectList(userRepository.List(), "userName", "email");
            ViewBag.Items = u; 
            @ViewData["id"] = id;
            ViewData["IdUser"] = IdUser;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Assign(int grade, int id, string userName, int IdUser)
        {
            @ViewData["id"] = id;
            if (ModelState.IsValid)
            {
                int idStudent = userRepository.GetByEmail(userName).id;
                homeworkRepository.Edit_Create_Grade(idStudent, id, grade);
                return RedirectToAction("Index", "HomeWork", new { IdUser = @ViewData["IdUser"] });
            }
            ViewData["IdUser"] = IdUser;
            return View();
        }

    }
}