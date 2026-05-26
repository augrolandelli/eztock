using EZtock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class Article : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid ProviderId { get; set; }
        public Client Provider { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public bool Weighable { get; set; }
        public string Plu { get; set; }
        public ICollection<Batch> Batches { get; set; }
        public decimal StockMin { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Iva { get; set; }
        public decimal CostPriceIva { get; set; }
        public decimal SalePriceIva { get; set; }
        public bool IsPublic { get; set; }
       
    }
}
