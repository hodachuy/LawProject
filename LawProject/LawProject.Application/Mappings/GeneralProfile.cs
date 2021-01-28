using LawProject.Application.Features.Products.Commands.CreateProduct;
using LawProject.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
