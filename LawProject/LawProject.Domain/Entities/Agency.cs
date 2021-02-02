using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Agency
    {
        public long AgencyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PAgencyID { get; set; }
        public int SortOrder { get; set; }
    }
}
