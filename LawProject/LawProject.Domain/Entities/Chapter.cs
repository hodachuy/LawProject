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
        public bool IsDelete { get; set; }
        public long LegalID { get; set; }
    }
}
