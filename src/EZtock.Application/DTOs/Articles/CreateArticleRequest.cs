using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.Articles
{
    public class CreateArticleRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Guid ProviderId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
        public bool Weighable { get; set; }
        public string Plu { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMin { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Iva { get; set; }
        public decimal CostPriceIva { get; set; }
        public decimal SalePriceIva { get; set; }
        public bool IsPublic { get; set; }
    }
}
