using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Domain.Entities
{
    public class LegalDocumentRelate
    {
        public long ID { set; get; }
        public long LegalSourceID { set; get; }
        public long LegalRelateID { set; get; }
        public long LegalTypeID { set; get; }
    }
}
