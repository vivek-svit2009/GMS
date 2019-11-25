﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Models;

namespace GMS.Controllers
{
    public class meet_our_mentorsController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        // GET: meet_our_mentors
        public ActionResult Index()
        {
            List<Mentor> list = new List<Mentor>();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("SelectAllMentor", con);

            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var bilVal = new Mentor();
                bilVal.Id = Convert.ToInt32(row["Id"].ToString());
                bilVal.Name = row["Name"].ToString();
                bilVal.Designation = row["YourRole"].ToString();
                bilVal.Address = row["Address"].ToString();
                bilVal.AreaOfInterest = row["AreaOfExperties"].ToString();
                bilVal.IsInvestor = row["IsInvestor"].ToString();
                bilVal.Image = row["Image"].ToString();
                list.Add(bilVal);
            }
                return View(list);
        }

    }
}