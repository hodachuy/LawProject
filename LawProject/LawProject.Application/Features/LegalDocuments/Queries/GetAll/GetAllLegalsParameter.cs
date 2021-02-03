using LawProject.Application.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Application.Features.LegalDocuments.Queries.GetAll
{
    public class GetAllLegalsParameter : RequestParameter
    {
        public Dictionary<string,string> ParamsFilter { get; set; }
    }
}
