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

            if (Session["UserEmail"] != null)
            {
                if (Session["UserType"].ToString() == "Mentor")
                {
                    return RedirectToAction("profile", "mentor");
                }
                else
                {
                    return RedirectToAction("profile", "startup");
                }
            }
            else
            {
                return View();
            }
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
                    Session["UserType"] = "User";
                    Session["UserEmail"] = form.email;
                    
                    return RedirectToAction("profile", "startup");
                }
                else
                {
                    Session["UserType"] = "User";
                    Session["UserEmail"] = form.email;
                    Response.Cookies.Add(new HttpCookie("StartupEmail", form.email));
                    return RedirectToAction("register_info", "startup");
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
                        Session["UserType"] = "Mentor";
                        Session["UserEmail"] = form.email;
                        return RedirectToAction("profile", "mentor");
                    }
                    else
                    {
                        Session["UserType"] = "Mentor";
                        Session["UserEmail"] = form.email;
                        Response.Cookies.Add(new HttpCookie("MentorEmail", form.email));
                        return RedirectToAction("register_info", "mentor");
                       
                    }
                }
                else
                {
                    ViewBag.Message = "UserName Or Password is incorrect";
                    return View();
                }
            }


            
        }
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("login", "user");
        }
    }
}