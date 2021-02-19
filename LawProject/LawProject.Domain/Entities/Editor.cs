using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Editor
    {
        public long EditorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PEditorID { get; set; }
        public int SortOrder { get; set; }
        public virtual IEnumerable<LegalDocument> LegalDocuments { get; set; }

    }
}
