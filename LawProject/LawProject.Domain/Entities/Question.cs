using LawProject.Domain.Common;
using LawProject.Domain.Enum;
using System.Collections.Generic;
using System.Linq;

namespace LawProject.Domain.Entities
{
    public class Question : AuditableBaseEntity
    {
        public long QuesID { get; set; }
        public string QuesCode { get; set; }
        public string QuesContent { get; set; }// Contents
        public string Title { get; set; }
        public string AccountID { get; set; }
        public long? AreaID { get; set; }
        public string QuesContentText { get; set; }
        public Status.QuestionAnswer StatusValue { get; set; } //Status
        public bool IsTraining { get; set; }// IsToAPI
        public long ViewCount { get; set; } // CountView
        public virtual Answer Answer { get; set; }
        public virtual Area Area { get; set; }
        public virtual IEnumerable<QuestionComment> QuestionComments { get; set; }
        public virtual IEnumerable<QuestionTag> QuestionTags { get; set; }
    }
}
