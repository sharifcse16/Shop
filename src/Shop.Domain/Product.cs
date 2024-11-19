using Shop.Products.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Shop
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Code { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }

        private Product()
        {
            
        }

        internal Product(CreateUpdateProductDomainDto dto)
        {
            Name = dto.Name;
            Code = dto.Code;
            PurchasePrice = dto.PurchasePrice;
            SalePrice = dto.SalePrice;
        }

        internal void Update(CreateUpdateProductDomainDto dto)
        {
            Name = dto.Name;
            Code = dto.Code;
            PurchasePrice = dto.PurchasePrice;
            SalePrice = dto.SalePrice;
        }

    }
}
