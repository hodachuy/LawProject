using LawProject.Domain.Common;
using LawProject.Domain.Enum;

namespace LawProject.Domain.Entities
{
    public class Question : AuditableBaseEntity
    {
        public long QuesID { get; set; }
        public string QuesCode { get; set; }
        public string QuesContent { get; set; }// Contents
        public string Title { get; set; }
        public string AccountID { get; set; }
        public string AreaID { get; set; }
        public string QuesContentText { get; set; }
        public Status.QuestionAnswer StatusValue { get; set; } //Status
        public bool IsTraining { get; set; }// IsToAPI
        public long ViewCount { get; set; } // CountView
    }
}
