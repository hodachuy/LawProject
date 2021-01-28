using LawProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
