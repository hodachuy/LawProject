using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Ward
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string LatiLongTude { get; set; }
		public int DistrictID { get; set; }
		public int SortOrder { get; set; }
		public bool IsPublished { get; set; }
		public bool IsDeleted { get; set; }
	}
}
