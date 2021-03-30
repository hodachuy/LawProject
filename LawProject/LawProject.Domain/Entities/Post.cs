using LawProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class Post : AuditableBaseEntity
	{
		public long PostID { set; get; }
		public string Name { set; get; }
		public string Alias { set; get; }
		public long PostCategoryID { set; get; }
		public string Image { set; get; }
		public string Description { set; get; }
		public string Content { set; get; }
		public bool IsPublished { set; get; }
		public int? ViewCount { set; get; }
		public virtual PostCategory PostCategory { set; get; }
		public virtual IEnumerable<PostTag> PostTags { set; get; }
	}
}
