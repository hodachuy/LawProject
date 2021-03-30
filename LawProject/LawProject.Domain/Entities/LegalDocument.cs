using LawProject.Domain.Common;
using LawProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class LegalDocument : AuditableBaseEntity
    {
        public long LegalID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string PublishNo { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsPublished { get; set; } // IsEffect
        public long? DocTypeID { get; set; }
        public long? AgencyID { get; set; }
        public long? AreaID { get; set; }
        public string LegalCode { get; set; }
        public string Notes { get; set; }
        public string SigningTitle { get; set; }
        public string SignerName { get; set; }
        public long ViewCount { get; set; }
        public long? EditorID { get; set; }
        public long? LegalTypeID { get; set; } // TypeLegalID
        public long? LegalRefID { get; set; } // RefLegalID
        public string Content { get; set; } // TextHtml toàn văn
        public string TableOfContents { get; set; } // StructureHtml
        public long LegalGroupID { get; set; }
        public Status.Legal StatusValue { get; set; } //Status
        public string EnglishContent { get; set; } // ContentEnglish
        public string BookAuthor { get; set; }
        public string CombineAgencyIDs { get; set; }
        public string FTS_FullContent { get; set; } //CombineTextSearch
        public int? DistrictID { get; set; }
        public int? ProvinceID { get; set; }
        public string FTS_FullTitle { get; set; } //TitleSearch
        public string FooterRecipients { get; set; }
        public string FooterSigner { get; set; }
        public string FooterAppendix { get; set; } // FooterQuote
        public bool IsTraining { get; set; }
        public bool IsHasAppendix { get; set; } // IsHaveAppendix
        public virtual LegalDocumentGroup LegalDocumentGroup { get; set; }
        public virtual Area Area { get; set; }
        public virtual DocumentsType DocumentsType { get; set; }
        public virtual Editor Editor { get; set; }
        public virtual Agency Agency { get; set; }
        public virtual LegalDocumentType LegalDocumentType { get;set;}
        public virtual District District { get; set; }
        public virtual Province Province { get; set; }
        public virtual IEnumerable<Part> Parts { get; set; }
        public virtual IEnumerable<LegalDocumentFile> LegalDocumentFiles { get; set; }
    }
}
