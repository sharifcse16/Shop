using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Shop.Products.DTOs
{
    public class ProductDto : EntityDto<Guid>
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}
