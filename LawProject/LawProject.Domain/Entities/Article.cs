using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Article
    {
        public long ArticleID { get; set; }
        public long ItemID { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Idx { get; set; }
        public bool IsDelete { get; set; }
        public long LegalID { get; set; }
        public string DocAttach { get; set; }
    }
}
