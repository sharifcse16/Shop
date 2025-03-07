using AutoMapper;
using Shop.Products.DTOs;

namespace Shop;

public class ShopApplicationAutoMapperProfile : Profile
{
    public ShopApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<Product,ProductDto>();
        CreateMap<CreateUpdateProductDto, CreateUpdateProductDomainDto>();
      
    }
}
