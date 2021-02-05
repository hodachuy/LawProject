using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class DocumentsType
    {
        public long DocID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? PDocID { get; set; }
        public long? LegalGroupID { get; set; }
        public int SortOrder { get; set; }
    }
}
