using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Part
    {
        public long PartID { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Idx { get; set; }
        public bool IsDelete { get; set; }
        public long LegalID { get; set; }
        public virtual LegalDocument LegalDocument { get; set; }
        public virtual IEnumerable<Chapter> Chapters { get; set; }

    }
}
