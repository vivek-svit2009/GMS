using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MentorLeftMenu()
        {
            return PartialView();
        }
        public ActionResult StartupRecommendation()
        {
            return PartialView();
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
        public ActionResult TopMenu()
        {
            return PartialView();
        }
    }
}