using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Controllers
{
    public class mentorController : Controller
    {
        // GET: mentor
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
        public ActionResult registration()
        {
            return View();
        }
    }
}