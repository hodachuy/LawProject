using LawProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Entities
{
    public class PostCategory : AuditableBaseEntity
	{
		public long PostCategoryID { set; get; }
		public string Name { set; get; }
		public string Alias { set; get; }
		public string Description { set; get; }
		public int? ParentID { set; get; }
		public int? DisplayOrder { set; get; }
		public string Image { set; get; }
		public virtual IEnumerable<Post> Posts { set; get; }
	}
}
