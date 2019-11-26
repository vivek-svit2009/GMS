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

                            SqlCommand cmd1 = new SqlCommand("SelectMentorProfile", con);
                            cmd1.CommandType = CommandType.StoredProcedure;

                            cmd1.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                            con.Open();

                            SqlDataReader dr = cmd1.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows)
                            {

                                MentorProfile mp = new MentorProfile
                                {

                                    Name = dr["Name"].ToString(),
                                    PrimaryIndustry = dr["PrimaryIndustry"].ToString(),
                                    BusinessMgtExp = dr["BusinessMgtExp"].ToString(),
                                    BusinessExpCountry = dr["BusinessExpCountry"].ToString(),
                                    OwnershipMgtExp = dr["OwnershipMgtExp"].ToString(),
                                    Achievements = dr["Achievements"].ToString(),
                                    AreaOfExperties = dr["AreaOfExperties"].ToString(),
                                    BusinessProblemInterest = dr["BusinessProblemInterest"].ToString(),
                                    AdvisingActivities = dr["AdvisingActivities"].ToString(),
                                    StageOfBusiness = dr["StageOfBusiness"].ToString(),
                                    WebLink = dr["WebLink"].ToString(),
                                    YourCompany = dr["YourCompany"].ToString(),
                                    YourRole = dr["YourRole"].ToString(),
                                    Language = dr["Language"].ToString(),
                                    Country = dr["Country"].ToString(),
                                    State = dr["State"].ToString(),
                                    City = dr["City"].ToString(),
                                    Pin = dr["Pin"].ToString(),
                                    IsInvestor = dr["IsInvestor"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Mobile = dr["Mobile"].ToString(),

                                    Image = dr["Image"].ToString()
                                };
                                ViewData["MyMP"] = mp;
                                return View();
                            }
                            else
                            {
                                return RedirectToAction("register_info", "mentor");
                            }
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
                            return View();
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
        [HttpPost]
        public ActionResult register_info(profileRegMentor reg)
        {

            string i1 = "";
            string i2 = "";
            string i3 = "";
            string i4 = "";
            string i5 = "";
            //var numbersAndWords = founder_name.Zip(founder_desc, (n, w) => new { founder_name = n, founder_desc = w });
            foreach (var item in reg.stages)
            {
                i1 = item + "," + i1;
            }
            foreach (var item in reg.countries)
            {
                i2 = item + "," + i2;
            }
            foreach (var item in reg.area_of_expertise)
            {
                i3 = item + "," + i3;
            }
            foreach (var item in reg.advising_activities)
            {
                i4 = item + "," + i4;
            }
            foreach (var item in reg.languages)
            {
                i5 = item + "," + i5;
            }

            try
            {



                SqlCommand cmd = new SqlCommand("AddMentorProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", Request.Cookies["MentorEmail"].Value.ToString());
                cmd.Parameters.AddWithValue("@PrimaryIndustry", reg.primary_industry);
                cmd.Parameters.AddWithValue("@BusinessMgtExp", reg.business_experience);
                cmd.Parameters.AddWithValue("@BusinessExpCountry", i2);
                cmd.Parameters.AddWithValue("@OwnershipMgtExp", reg.ownership_experience);
                cmd.Parameters.AddWithValue("@Achievements", reg.achievements);
                cmd.Parameters.AddWithValue("@AreaOfExperties", i3);
                cmd.Parameters.AddWithValue("@BusinessProblemInterest", reg.business_problems);
                cmd.Parameters.AddWithValue("@AdvisingActivities", i4);
                cmd.Parameters.AddWithValue("@StageOfBusiness", i1);
                cmd.Parameters.AddWithValue("@WebLink", reg.website_link);
                cmd.Parameters.AddWithValue("@YourCompany", reg.company);
                cmd.Parameters.AddWithValue("@YourRole", reg.role_at_company);
                cmd.Parameters.AddWithValue("@Language", i5);
                cmd.Parameters.AddWithValue("@Country", reg.residence_country);
                cmd.Parameters.AddWithValue("@State", reg.residence_state);
                cmd.Parameters.AddWithValue("@City", reg.residence_city);
                cmd.Parameters.AddWithValue("@Pin", reg.postal_code);
                cmd.Parameters.AddWithValue("@IsInvestor", reg.invest_opportunity);




                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {

                    int j;
                    for (j = 0; j < reg.industry_roles.Length; j++)
                    {
                        SqlCommand cmd2 = new SqlCommand("AddMentorRolePlayed", con);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.AddWithValue("@email", Request.Cookies["MentorEmail"].Value.ToString());
                        cmd2.Parameters.AddWithValue("@Role", reg.industry_roles[j]);
                        cmd2.Parameters.AddWithValue("@Company", reg.your_company[j]);
                        cmd2.Parameters.AddWithValue("@Contribution", reg.contribution[j]);
                        int i6 = cmd2.ExecuteNonQuery();
                    }
                }
                con.Close();

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