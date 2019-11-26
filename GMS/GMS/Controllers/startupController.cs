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
    public class startupController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        // GET: startup
        public ActionResult profile()
        {
            if (Session["UserEmail"] != null)
            {
                if (Session["UserType"].ToString() == "Mentor")
                {
                    SqlCommand cmd = new SqlCommand("SelectMentorIsProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();
                    var IsProfile = cmd.ExecuteScalar();
                    con.Close();
                    if (IsProfile != null)
                    {
                        if (IsProfile.ToString() == "True")
                        {
                            return View();
                        }
                        else
                        {
                            return RedirectToAction("register_info", "mentor");
                        }
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SelectStartupIsProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();
                    var IsProfile = cmd.ExecuteScalar();
                    con.Close();
                    if (IsProfile != null)
                    {
                        if (IsProfile.ToString() == "True")
                        {
                            return View();
                        }
                        else
                        {
                            return RedirectToAction("register_info", "startup");

                        }
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
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
        [HttpPost]
        public ActionResult Registration(Registration reg)
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
            
            
            SqlCommand cmd = new SqlCommand("AddNewUser", con);
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
           
            return RedirectToAction("Registration", "startup");
        }
        public ActionResult register_info()
        {

            if (Session["UserEmail"] != null)
            {
                if (Session["UserType"].ToString() == "Mentor")
                {
                    SqlCommand cmd = new SqlCommand("SelectMentorIsProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();
                    var IsProfile = cmd.ExecuteScalar();
                    con.Close();
                    if (IsProfile != null)
                    {
                        if (IsProfile.ToString() == "True")
                        {
                            return RedirectToAction("profile", "mentor");
                        }
                        else
                        {
                            return RedirectToAction("register_info", "mentor");
                        }
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SelectStartupIsProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();
                    var IsProfile = cmd.ExecuteScalar();
                    con.Close();
                    if (IsProfile != null)
                    {
                        if (IsProfile.ToString() == "True")
                        {
                            return RedirectToAction("profile", "startup");
                        }
                        else
                        {
                            return View();
                        }
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
            }
            else
            {
                return RedirectToAction("login", "user");
            }

        }
        [HttpPost]
        public ActionResult register_info(profileRegStartup reg)
        {
            string ii = "";
            string iii = "";
            //var numbersAndWords = founder_name.Zip(founder_desc, (n, w) => new { founder_name = n, founder_desc = w });
            foreach (var item in reg.stages)
            {
                ii = item + "," + ii;
            }
            foreach (var item in reg.specific_area)
            {
                iii = item + "," + iii;
            }

            try
            {
                if (reg.company_logo.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(reg.company_logo.FileName);
                    string _path = Path.Combine(Server.MapPath("~/StartupLogo"), _FileName);
                    reg.company_logo.SaveAs(_path);

                    SqlCommand cmd = new SqlCommand("AddProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Request.Cookies["StartupEmail"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Stage", ii);
                    cmd.Parameters.AddWithValue("@Company", reg.startup_name);
                    cmd.Parameters.AddWithValue("@LookingFor", reg.look_for);
                    cmd.Parameters.AddWithValue("@StartupHighlight", reg.short_highlight);
                    cmd.Parameters.AddWithValue("@Logo", "/StartupLogo/" + _FileName);
                    cmd.Parameters.AddWithValue("@productSummary", reg.service_summary);
                    cmd.Parameters.AddWithValue("@WebSite", reg.website_link);
                    cmd.Parameters.AddWithValue("@Industry", reg.industry);
                    cmd.Parameters.AddWithValue("@YearOfInco", reg.year);
                    cmd.Parameters.AddWithValue("@AnnualRev", reg.revenue);
                    cmd.Parameters.AddWithValue("@Currency", reg.currency);
                    cmd.Parameters.AddWithValue("@TeamSize", reg.team_size);
                    cmd.Parameters.AddWithValue("@AreaForMentro", iii);
                    cmd.Parameters.AddWithValue("@Segmentation", reg.breakup);
                    cmd.Parameters.AddWithValue("@MentorEngagement", reg.engagement);
                    cmd.Parameters.AddWithValue("@Role", reg.industry_roles);
                    cmd.Parameters.AddWithValue("@Exp", reg.professional_experience);
                    cmd.Parameters.AddWithValue("@Position", reg.last_position);
                    cmd.Parameters.AddWithValue("@FoundingTeam", reg.members_count);
                    cmd.Parameters.AddWithValue("@IsOpenForPartner", reg.other_startup_link);



                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        var numbersAndWords = reg.founder_name.Zip(reg.founder_desc, (n, w) => new { founder_name = n, founder_desc = w });
                        foreach (var item in numbersAndWords)
                        {
                            SqlCommand cmd1 = new SqlCommand("AddUserTeam", con);
                            cmd1.CommandType = CommandType.StoredProcedure;

                            cmd1.Parameters.AddWithValue("@email", Request.Cookies["StartupEmail"].Value.ToString());
                            cmd1.Parameters.AddWithValue("@FounderName", item.founder_name);
                            cmd1.Parameters.AddWithValue("@Description", item.founder_desc);
                            int i1 = cmd1.ExecuteNonQuery();
                        }
                        int j;
                        for (j = 0; j < reg.education.Length; j++)
                        {
                            SqlCommand cmd2 = new SqlCommand("AddUserEdu", con);
                            cmd2.CommandType = CommandType.StoredProcedure;

                            cmd2.Parameters.AddWithValue("@email", Request.Cookies["StartupEmail"].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Education", reg.education[j]);
                            cmd2.Parameters.AddWithValue("@Institute", reg.institute[j]);
                            cmd2.Parameters.AddWithValue("@Year", reg.edu_year[j]);
                            int i2 = cmd2.ExecuteNonQuery();
                        }
                    }
                    con.Close();




                }
                ViewBag.response = "Success";
                return View();
            }
            catch (Exception e)
            {

                ViewBag.response = "" + e;
                return View();
            }


            
        }
    }
}