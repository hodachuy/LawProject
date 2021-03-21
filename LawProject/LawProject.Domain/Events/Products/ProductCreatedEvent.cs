using LawProject.Domain.Common;
using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Domain.Events.Products
{
    public class ProductCreatedEvent : DomainEvent
    {
        public ProductCreatedEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}
