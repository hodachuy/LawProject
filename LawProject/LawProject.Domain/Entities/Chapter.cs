using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Chapter
    {
        public long ChapID { get; set; }
        public long PartID { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Idx { get; set; }
        public bool IsDeleted { get; set; }
        public long LegalID { get; set; }
        public virtual Part Part { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }
    }
}
