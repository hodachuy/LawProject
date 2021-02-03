using LawProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class LawOffice : AuditableBaseEntity
    {
        public long LawOfficeID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string LegalRepresentativeName { get; set; }
        public int? DistrictID { get; set; }
        public int? ProvinceID { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int SortOrder { get; set; }
        public bool IsPublish { get; set; }
    }
}
