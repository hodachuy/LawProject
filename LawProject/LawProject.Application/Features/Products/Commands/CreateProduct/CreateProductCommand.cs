using LawProject.Application.Interfaces.Repositories;
using LawProject.Application.Wrappers;
using AutoMapper;
using LawProject.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.Products.Commands.CreateProduct
{
    public partial class CreateProductCommand : IRequest<Response<long>>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<long>>
    {
        private readonly IProductRepositoryAsync _productRepository;

        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product);
            return new Response<long>(product.Id);
        }
    }
}
