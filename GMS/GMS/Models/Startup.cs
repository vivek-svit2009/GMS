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
}