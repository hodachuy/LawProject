using LawProject.Domain.Enum;
using System;

namespace LawProject.Domain.Entities
{
    public class Notifiation
    {
		public int ID { get; set; }
		public string Message { get; set; }
		public int? SenderID { get; set; }
		public int? RecipientID { get; set; }
		public string EntityName { get; set; }
		public string EntityID { get; set; }
		public Status.Notify StatusValue { get; set; }
		public DateTime CreatedDate { get; set; }
		public string URL { get; set; }
	}
}
