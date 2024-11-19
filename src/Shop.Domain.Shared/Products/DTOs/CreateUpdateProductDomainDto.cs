using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Products.DTOs
{
    public class CreateUpdateProductDomainDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Code { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}
