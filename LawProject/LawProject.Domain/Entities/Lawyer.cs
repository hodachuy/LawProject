using LawProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Lawyer : AuditableBaseEntity
    {
        public long LawyerID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Areas { get; set; }
        public string AreaTitles { get; set; }
        public string Organization { get; set; }
        public int ExperienceYear { get; set; } 
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string SocialNetwork { get; set; }
        public string AccountID { get; set; }
        public long? LawOfficeID { get; set; }
        public int? DistrictID { get; set; }
        public int? ProvinceID { get; set; }
        public int SortOrder { get; set; }
        public bool IsPublished { get; set; }
    }
}
