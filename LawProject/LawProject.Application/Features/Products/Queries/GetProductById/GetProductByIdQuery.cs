using AutoMapper;
using LawProject.Application.Exceptions;
using LawProject.Application.Features.Products.Queries.GetAllProducts;
using LawProject.Application.Interfaces.Repositories;
using LawProject.Application.Wrappers;
using LawProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<Product>>
    {
        public long Id { get; set; }
    }
    public class GetStatusByIdQuery : IRequest<Response<Product>>
    {
        public long Id { get; set; }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<Product>>,
                                              IRequestHandler<GetStatusByIdQuery, Response<Product>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Response<Product>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetSingleByCondition(x => x.Id == query.Id, null, x => new Product() { Id = x.Id, Name = x.Name });
            if (product == null) throw new ApiException($"Product Not Found.");
            return new Response<Product>(product);
        }

        public async Task<Response<Product>> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetSingleByCondition(x => x.Id == request.Id);
            if (product == null) throw new ApiException($"Product Not Found.");
            return new Response<Product>(product);
        }
    }
}
