using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class QuestionComment
    {
        public long CommentID { get; set; }
        public string Content { get; set; }
        public string ContentText { get; set; }
        public bool IsSolution { get; set; }
        public bool FlaggedAsSpam { get; set; }
        public string IpAddress { get; set; }
        public bool Pending { get; set; }
        public string AccountID { get; set; }
        public long QuesID { get; set; }
        public long VoteLike { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
