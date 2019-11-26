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
    public class profileRegMentor
    {
        public string primary_industry { get; set; }
        public string business_experience { get; set; }
        public List<string> countries { get; set; }
        public string ownership_experience { get; set; }
        public string[] industry_roles { get; set; }
        public List<string> your_company { get; set; }
        public List<string> contribution { get; set; }
        public string achievements { get; set; }
        public List<string> area_of_expertise { get; set; }
        public string business_problems { get; set; }
        public List<string> advising_activities { get; set; }
        public List<string> stages { get; set; }
        public string website_link { get; set; }
        public string company { get; set; }
        public string role_at_company { get; set; }
        public List<string> languages { get; set; }
        public string residence_country { get; set; }
        public string residence_state { get; set; }
        public string residence_city { get; set; }
        public string postal_code { get; set; }
        public string invest_opportunity { get; set; }
    }
    public class MentorProfile
    {

        public string Name { get; set; }
        public string PrimaryIndustry { get; set; }
        public string BusinessMgtExp { get; set; }
        public string BusinessExpCountry { get; set; }
        public string OwnershipMgtExp { get; set; }
        public string Achievements { get; set; }
        public string AreaOfExperties { get; set; }
        public string BusinessProblemInterest { get; set; }
        public string AdvisingActivities { get; set; }
        public string StageOfBusiness { get; set; }
        public string WebLink { get; set; }
        public string YourCompany { get; set; }
        public string YourRole { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string IsInvestor { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string Image { get; set; }

}
}