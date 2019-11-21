using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Models;

namespace GMS.Controllers
{
    public class userController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        // GET: user
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(LoginUser form)
        {
            SqlCommand cmd = new SqlCommand("Select IsProfile from tbl_User where Email='" + form.email + "' and Password='" + form.password + "' ", con);
            con.Open();
            var IsProfile = cmd.ExecuteScalar();
            con.Close();
            if (IsProfile != null)
            {
                if (IsProfile.ToString() == "True")
                {
                    Session["UserEmail"] = form.email;
                    return RedirectToAction("profile", "mentor");
                }
                else
                {
                    return RedirectToAction("register_info", "mentor");
                }
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("Select IsProfile from tbl_Mentor where Email='" + form.email + "' and Password='" + form.password + "' ", con);
                con.Open();
                var IsProfile1 = cmd1.ExecuteScalar();
                con.Close();
                if (IsProfile1 != null)
                {

                    if (IsProfile1.ToString() == "True")
                    {
                        Session["UserEmail"] = form.email;
                        return RedirectToAction("profile", "startup");
                    }
                    else
                    {
                        return RedirectToAction("register_info", "startup");
                    }
                }
                else
                {
                    ViewBag.Message = "UserName Or Password is incorrect";
                    return View();
                }
            }


            
        }
    }
}