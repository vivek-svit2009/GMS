using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMS.Models
{
    public class Mentor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string AreaOfInterest { get; set; }
        public string Image { get; set; }
        public string IsInvestor { get; set; }
    }
}