using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Controllers
{
    public class startupController : Controller
    {
        // GET: startup
        public ActionResult profile()
        {
            if (Session["UserEmail"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "user");
            }
        }
        public ActionResult Registration()
        {
            return View();
        }
    }
}