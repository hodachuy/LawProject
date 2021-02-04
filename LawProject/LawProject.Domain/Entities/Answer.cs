using LawProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Answer : AuditableBaseEntity
    {
        public long AnswerID { get; set; }
        public string AnswerContent { get; set; }
        public string AccountID { get; set; }
        public long QuesID { get; set; }
        public virtual Question Question { get; set; }
    }
}
