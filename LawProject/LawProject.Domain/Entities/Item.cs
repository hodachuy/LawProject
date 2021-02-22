using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Item
    {
        public long ItemID { get; set; }
        public long ChapID { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Idx { get; set; }
        public bool IsDelete { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual IEnumerable<Article> Articles { get; set; }

    }
}
