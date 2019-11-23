using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMS.Models
{
    public class StartupRecommendation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Image { get; set; }
    }
    public class DemoRecommendation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public string Time { get; set; }
        public string Address { get; set; }
    }
    public class MentorRecommendation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrimaryIndustry { get; set; }
        public string Image { get; set; }
    }
}