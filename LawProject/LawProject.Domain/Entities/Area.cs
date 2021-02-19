using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Area
    {
        public long AreaID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public long? PAreaID { get; set; }
        public int SortOrder { get; set; }
        public virtual IEnumerable<LegalDocument> LegalDocuments { get; set; }
        public virtual IEnumerable<Question> Questions { get; set; }
    }
}
