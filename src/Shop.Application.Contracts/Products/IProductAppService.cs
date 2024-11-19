using Shop.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Shop.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> CreateAsync(CreateUpdateProductDto dto);
        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input);
        Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input);
    }
}
