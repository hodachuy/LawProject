﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Domain.Entities
{
    public class LegalDocumentType
    {
        public long LegalTypeID {get; set;}
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public virtual IEnumerable<LegalDocument> LegalDocuments { get; set; }

    }
}
