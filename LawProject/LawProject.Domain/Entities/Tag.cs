using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Tag
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual IEnumerable<QuestionTag> QuestionTags { get; set; }

    }
}
