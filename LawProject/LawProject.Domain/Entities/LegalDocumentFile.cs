using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class LegalDocumentFile
    {
        public long FileID { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedDate { get; set; }
        public long LegalID { get; set; }
        public string AccountID { get; set; }
        public virtual LegalDocument LegalDocument { get; set; }
    }
}
