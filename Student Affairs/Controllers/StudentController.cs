using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Affairs.Models;
namespace Student_Affairs.Controllers
{
    public class StudentController : Controller
    {

        private Entities1 db = new Entities1();
        // GET: Student
        public ActionResult AddStudent()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login/Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(Student_Affairs.Models.Student request)
        {
            if (Session["UserID"] != null)
            {
                if (ModelState.IsValid)
                {
                    
                    db.Students.Add(request);
                    db.SaveChanges();
                    ModelState.Clear();
                    return View();
                }
                return View(request);
            }
            else { return RedirectToAction("../Login/Index"); }
        }

        [HttpGet]
        public ActionResult ViewStudents()
        {
            ViewBag.student = db.Students.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ViewStudents(string filter)
        {
            switch (filter)
            {
                case "all":
                    ViewBag.student = db.Students.ToList();
                    break;
                case "Level 1":
                    ViewBag.student = db.Students.Where(o => o.level == 1).ToList();
                    break;
                case "Level 2":
                    ViewBag.student = db.Students.Where(o => o.level == 2).ToList();
                    break;
                case "Level 3":
                    ViewBag.student = db.Students.Where(o => o.level == 3).ToList();
                    break;
                case "Level 4":
                    ViewBag.student = db.Students.Where(o => o.level == 4).ToList();
                    break;
                default:
                    ViewBag.student = db.Students.ToList();
                    break;

            }
           
            return View();
        }
        [HttpGet]
        public ActionResult EditStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditStudent(int id)
        {
            return View();
        }

    }
}