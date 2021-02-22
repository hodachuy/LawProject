using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class PostTag
    {
        public int PostID { set; get; }
        public string TagID { set; get; }
        public virtual Post Post { set; get; }
        public virtual Tag Tag { set; get; }
    }
}
