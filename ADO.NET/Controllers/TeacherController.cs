using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO.NET.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }        
        
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}