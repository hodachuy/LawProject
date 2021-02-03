using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class UploadFile
    {
        public long FileID { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? QuesID { get; set; }
        public long? CommentID { get; set; }
        public long? AnswerID { get; set; }
        public long? LegalID { get; set; }
        public string AccountID { get; set; }
    }
}
