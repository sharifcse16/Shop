using AutoMapper.Internal.Mappers;
using Shop.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;



namespace Shop.Products
{
    public class ProductAppService :  ShopAppService, IProductAppService
    {
        private readonly ProductManager _productManager;
        //  private readonly IRepository<Product,Guid> _productRepository;
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository, ProductManager productManager)
        {
            _productRepository = productRepository;
            _productManager = productManager;
        }


        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto dto)
        {
            var domainDto = ObjectMapper.Map<CreateUpdateProductDto, CreateUpdateProductDomainDto>(dto);

            Product product = _productManager.CreateAsync(domainDto);
            await _productRepository.InsertAsync(product);

            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
        {

            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Product.Name);
            }

            var products = await _productRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _productRepository.CountAsync()
                : await _productRepository.CountAsync(
                product => product.Name.Contains(input.Filter));

            return new PagedResultDto<ProductDto>(
                totalCount,
                ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
            );
        }

        public async Task<ProductDto>GetAsync(Guid id)
        {
            Product product = await _productRepository.GetAsync(id);
            if (product == null)
                throw new Exception("Product not found");
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto>UpdateAsync(Guid id,CreateUpdateProductDto input)
        {

            var product = await _productRepository.GetAsync(id);
            if (product == null)
                throw new Exception("Product not found");

            var domainDto = ObjectMapper.Map<CreateUpdateProductDto, CreateUpdateProductDomainDto>(input);

            product = _productManager.UpdateAsync(product,domainDto);
            await _productRepository.UpdateAsync(product);
            return ObjectMapper.Map<Product,ProductDto>(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

    }
}
