using LawProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Application.Features.LegalDocuments.Queries.GetAll
{
    public class GetAllLegalsViewModel
    {
        public long LegalID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string LegalCode { get; set; }
        public Status.Legal StatusValue { get; set; }
    }
}
