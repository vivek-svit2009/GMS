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
            return View();
        }
    }
}