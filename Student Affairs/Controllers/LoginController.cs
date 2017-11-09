using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Affairs.Models;

namespace Student_Affairs.Controllers
{
    public class LoginController : Controller
    {
        private Entities1 db = new Entities1();
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return View();
            }
            return RedirectToAction("../Student/AddStudent");
        }
        [HttpPost]
        public ActionResult Index(Student_Affairs.Models.Student_Affairs user)
        {

            var usr = db.Student_Affairs.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            if (usr != null)
            {
                Session["UserID"] = usr.id.ToString();
     

                ModelState.AddModelError("", "Login Faild !!!");

                return RedirectToAction("../Student/AddStudent");


            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wronge");
            }

            return View();
        }

      
    }
}