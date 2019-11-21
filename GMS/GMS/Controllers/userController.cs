using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Models;

namespace GMS.Controllers
{
    public class userController : Controller
    {
        // GET: user
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public string login(LoginUser form)
        {
          
            string UserName = form.email;
            string Password = form.password;
           
            return UserName + Password;
        }
    }
}