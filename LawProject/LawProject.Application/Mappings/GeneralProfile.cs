using LawProject.Application.Features.Products.Commands.CreateProduct;
using LawProject.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using LawProject.Application.Features.LegalDocuments.Commands.Create;
using LawProject.Application.Features.LegalDocuments.Queries.GetAll;
using LawProject.Application.Features.QuestionAnswers.Commands.Create;

namespace LawProject.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<CreateLegalCommand, LegalDocument>();
            CreateMap<GetAllLegalsQuery, GetAllLegalsParameter>();


            CreateMap<CreateQuestionAnswerFrAdminCommand, Question>();


        }
    }
}
