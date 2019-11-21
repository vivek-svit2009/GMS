using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Controllers
{
    public class userController : Controller
    {
        // GET: user
        public ActionResult login()
        {
            return View();
        }
    }
}