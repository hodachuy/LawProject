using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Infrastructure.Persistence.Seeds
{
    public class DefaultProduct
    {
        private IProductRepositoryAsync _productRepository;
        public async Task SeedCreateProductDemo(IProductRepositoryAsync productRepository)
        {
            _productRepository = productRepository;
            //Seed Default User
            var defaultProduct = new Product
            {
                Name = "ABC",
                Barcode = "123456",
                Description = "Mo ta",
                IsDeleted = false
            };
            await _productRepository.AddAsync(defaultProduct);
        }
    }
}
