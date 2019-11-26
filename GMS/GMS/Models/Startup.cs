using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMS.Models
{
    public class Registration
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string profile_image { get; set; }
    }
    public class profileRegStartup
    {
        public string email { get; set; }
        public string[] stages { get; set; }
        public string startup_name { get; set; }
        public string look_for { get; set; }
        public string short_highlight { get; set; }
        public string service_summary { get; set; }
        public string website_link { get; set; }
        public string industry { get; set; }
        public HttpPostedFileBase company_logo { get; set; }
        public string year { get; set; }
        public string revenue { get; set; }
        public string currency { get; set; }
        public string team_size { get; set; }
        public string[] specific_area { get; set; }
        public string breakup { get; set; }
        public string engagement { get; set; }
        public string industry_roles { get; set; }
        public string professional_experience { get; set; }
        public string last_position { get; set; }
        public string members_count { get; set; }
        public string[] founder_name { get; set; }
        public string[] founder_desc { get; set; }
        public string other_startup_link { get; set; }
        public string[] education { get; set; }
        public string[] institute { get; set; }
        public string[] edu_year { get; set; }
    }
}