using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Domain.Entities
{
    public class LegalDocumentType
    {
        public long LegalTypeID {set;get;}
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
    }
}
