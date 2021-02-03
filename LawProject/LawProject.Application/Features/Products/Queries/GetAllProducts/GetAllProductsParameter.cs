using LawProject.Application.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsParameter : RequestParameter
    {
        public string Keyword { get; set; }
    }
}
