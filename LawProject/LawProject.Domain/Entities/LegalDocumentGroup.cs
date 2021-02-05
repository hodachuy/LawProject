using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Domain.Entities
{
    public class LegalDocumentGroup
    {
        public long LegalGroupID { get; set;}
        public string Name { get; set; }
        public string Alias { get; set; }
        public long? Value { get; set; }
        public int SortOrder { get; set; }
        public virtual IEnumerable<LegalDocument> LegalDocuments { get; set; }
    }
}
