using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Models;

namespace GMS.Controllers
{
    public class LayoutController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MentorLeftMenu()
        {
            if (Session["UserEmail"] != null)
            {
                if (Session["UserType"].Equals("Mentor"))
                {
                    SqlCommand cmd = new SqlCommand("SelectMentorProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {

                        MentorTopItem mp = new MentorTopItem
                        {

                            Name = dr["Name"].ToString(),
                            Image = dr["Image"].ToString(),
                            Email = dr["Email"].ToString()


                        };
                        ViewData["MyMP"] = mp;

                        con.Close();
                        return PartialView();
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
                else if (Session["UserType"].Equals("User"))
                {
                    SqlCommand cmd = new SqlCommand("SelectUserProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {

                        MentorTopItem mp = new MentorTopItem
                        {

                            Name = dr["Name"].ToString(),
                            Image = dr["Image"].ToString(),
                            Email = dr["Email"].ToString()

                        };
                        ViewData["MyMP"] = mp;

                        con.Close();
                        return PartialView();
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
                else
                {
                    return RedirectToAction("login", "user");
                }

            }
            else
            {
                return PartialView() ;
            }
        }
        public ActionResult StartupRecommendation()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.StartupRecommendation = GetStartups();
            mymodel.DemoRecommendation = GetDemos();

            return PartialView(mymodel);
        }
        public List<StartupRecommendation> GetStartups()
        {
            List<StartupRecommendation> list = new List<StartupRecommendation>();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SelectAllUser", con);

            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var startupRecommendation = new StartupRecommendation();
                startupRecommendation.Id = Convert.ToInt32(row["Id"].ToString());
                startupRecommendation.Name = row["Name"].ToString();
                startupRecommendation.Image = row["Image"].ToString();
                startupRecommendation.Industry = row["Industry"].ToString();

                list.Add(startupRecommendation);

            }
            return list;
        }
        public List<DemoRecommendation> GetDemos()
        {
            List<DemoRecommendation> DemoRecommendation = new List<DemoRecommendation>();
            DemoRecommendation.Add(new DemoRecommendation { Id = 1, Date = "21-Nov-2019", Name = "Amit Gupta", Time = "10:00 am" ,Image="knkn", Address= "St Johns Auditorium" });
            DemoRecommendation.Add(new DemoRecommendation { Id = 2, Date = "20-Nov-2019", Name = "Chetan Gujjar", Time = "10:00 am", Image = "knkn", Address = "St Johns Auditorium" });
            DemoRecommendation.Add(new DemoRecommendation { Id = 3, Date = "19-Nov-2019", Name = "Bhavin Patel", Time = "10:00 am", Image = "knkn", Address = "St Johns Auditorium" });
            return DemoRecommendation;
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
        public ActionResult TopMenu()
        {
            if (Session["UserEmail"] != null)
            {
                if (Session["UserType"].ToString()=="Mentor")
                {
                    SqlCommand cmd = new SqlCommand("SelectMentorTop", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {

                        MentorTopItem mp = new MentorTopItem
                        {

                            Name = dr["Name"].ToString(),
                            Image = dr["Image"].ToString(),


                        };
                        ViewData["MyMP"] = mp;

                        con.Close();
                        return PartialView();
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
                else if (Session["UserType"].ToString()=="User")
                {
                    SqlCommand cmd = new SqlCommand("SelectUserTop", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {

                        MentorTopItem mp = new MentorTopItem
                        {

                            Name = dr["Name"].ToString(),
                            Image = dr["Image"].ToString(),


                        };
                        ViewData["MyMP"] = mp;

                        con.Close();
                        return PartialView();
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
                else
                {
                    return RedirectToAction("login", "user");
                }
               
            }
            else
            {
                return PartialView();
            }
        }
        public ActionResult StartupLeftMenu()
        {
            if (Session["UserEmail"] != null)
            {
                if (Session["UserType"].Equals("Mentor"))
                {
                    SqlCommand cmd = new SqlCommand("SelectMentorProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {

                        MentorTopItem mp = new MentorTopItem
                        {

                            Name = dr["Name"].ToString(),
                            Image = dr["Image"].ToString(),
                            Email = dr["Email"].ToString()


                        };
                        ViewData["MyMP"] = mp;

                        con.Close();
                        return PartialView();
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
                else if (Session["UserType"].Equals("User"))
                {
                    SqlCommand cmd = new SqlCommand("SelectUsersProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@email", Session["UserEmail"].ToString());
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {

                        MentorTopItem mp = new MentorTopItem
                        {

                            Name = dr["Name"].ToString(),
                            Image = dr["Image"].ToString(),
                            Email = dr["Email"].ToString()

                        };
                        ViewData["MyMP"] = mp;

                        con.Close();
                        return PartialView();
                    }
                    else
                    {
                        return RedirectToAction("login", "user");
                    }
                }
                else
                {
                    return RedirectToAction("login", "user");
                }

            }
            else
            {
                return PartialView();
            }
        }
        public ActionResult MentorRecommendation()
        {
            List<MentorRecommendation> list = new List<MentorRecommendation>();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SelectAllMentor", con);

            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var MentorRecommendation = new MentorRecommendation();
                MentorRecommendation.Id = Convert.ToInt32(row["Id"].ToString());
                MentorRecommendation.Name = row["Name"].ToString();
                MentorRecommendation.Image = row["Image"].ToString();
                MentorRecommendation.PrimaryIndustry = row["PrimaryIndustry"].ToString();

                list.Add(MentorRecommendation);

            }
            return PartialView(list);
        }
    }
}