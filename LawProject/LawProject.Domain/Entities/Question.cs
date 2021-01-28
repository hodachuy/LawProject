using LawProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Question : AuditableBaseEntity
    {
        public long QuesID { get; set; }
        public string Contents { get; set; }
        public string Title { get; set; }
        public string AttachFileUrl { get; set; }
        public string AccountID { get; set; }
        public string IsDelete { get; set; }
        public string AreaID { get; set; }
        public string AreaTitle { get; set; }
        public string ContentsText { get; set; }
        public string ContentsAnswer { get; set; }
    }
}
