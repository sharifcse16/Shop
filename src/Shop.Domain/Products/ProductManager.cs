using Shop.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Shop.Products
{
    public class ProductManager : DomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateAsync(CreateUpdateProductDomainDto dto)
        {
            Product product = new Product(dto);
            return product;
        }

        public Product UpdateAsync(Product product,CreateUpdateProductDomainDto domain)
        {
            product.Update(domain);
            return product;
        }

        
    }
}
