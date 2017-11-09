using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Affairs.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Logout()
        {
            if (Session["UserID"] != null)
            {
                Session.Abandon();
                Session.Remove("Id");
                Session["Id"] = null;
                Session.Clear();
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                Response.Cache.SetNoStore();
                return RedirectToAction("../Login/Index");
            }
            else
            {
                return RedirectToAction("../Login/Index");
            }
        }
    }
}