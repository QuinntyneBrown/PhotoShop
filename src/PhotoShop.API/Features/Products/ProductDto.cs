using PhotoShop.Core.Models;
using System;

namespace PhotoShop.API.Features.Products
{
    public class ProductDto
    {        
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public static ProductDto FromProduct(Product product)
            => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Version = product.Version
            };
    }
}
