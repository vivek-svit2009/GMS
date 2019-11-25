using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Models;

namespace GMS.Controllers
{
    public class mentorController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

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
        [HttpPost]
        public ActionResult registration(Registration reg)
        {
            var sourcePath = Path.Combine(Server.MapPath("~/assets/Uploads/temp_upload"), reg.profile_image);
            var destinationPath = Path.Combine(Server.MapPath("~/assets/Uploads/frontuser/"));
            string ext = Path.GetExtension(sourcePath);
            string gui = "";
            if (System.IO.File.Exists(sourcePath))
            {
                gui = destinationPath + Guid.NewGuid().ToString() + ext;
                System.IO.File.Move(sourcePath, gui);
            }


            SqlCommand cmd = new SqlCommand("AddNewMentor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", reg.name);
            cmd.Parameters.AddWithValue("@Email", reg.email);
            cmd.Parameters.AddWithValue("@Mobile", reg.phone);
            cmd.Parameters.AddWithValue("@Password", reg.password);
            cmd.Parameters.AddWithValue("@Image", Path.GetFileName(gui));
            cmd.Parameters.AddWithValue("@IsProfile", "False");
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                ViewBag.Message = string.Format("{0}", "Registered Successfully");
            }
            else
            {
                ViewBag.Message = string.Format("{0}", "Their are some problem in registering you");
            }
            con.Close();

            return RedirectToAction("Registration", "mentor");
        }
    }
}