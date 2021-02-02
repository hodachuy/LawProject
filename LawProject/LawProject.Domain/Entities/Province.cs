using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Province
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public int TelephoneCode { get; set; }
		public int CountryID { get; set; }
		public string CountryCode { get; set; }
		public string ZipCode { get; set; }
		public int SortOrder { get; set; }
		public bool IsPublished { get; set; }
		public bool IsDeleted { get; set; }
	}
}
