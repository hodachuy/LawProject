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
        public string Description { get; set; }
        public int LegalGroupValue { get; set; }
    }
}
