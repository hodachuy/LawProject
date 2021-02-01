using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool IsDelete { get; set; }
    }
}
