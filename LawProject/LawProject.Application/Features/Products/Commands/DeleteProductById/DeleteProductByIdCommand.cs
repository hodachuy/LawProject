using LawProject.Application.Exceptions;
using LawProject.Application.Interfaces.Repositories;
using LawProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.Products.Commands.DeleteProductById
{
    public class DeleteProductByIdCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Response<long>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public DeleteProductByIdCommandHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<long>> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id);
                if (product == null) throw new ApiException($"Product Not Found.");
                await _productRepository.DeleteAsync(product);
                return new Response<long>(product.Id);
            }
        }
    }
}
