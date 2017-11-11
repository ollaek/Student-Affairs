﻿using System;
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
            ViewBag.level1 = db.Students.Where(o => o.level == 1).ToList();
            ViewBag.level2 = db.Students.Where(o => o.level == 2).ToList();
            ViewBag.level3 = db.Students.Where(o => o.level == 3).ToList();
            ViewBag.level4 = db.Students.Where(o => o.level == 4).ToList();

            return View();
        }

    }
}