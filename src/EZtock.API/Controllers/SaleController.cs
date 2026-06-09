using EZtock.Application.DTOs.Sales;
using EZtock.Application.Exceptions;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public SaleController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        [HttpPost]
        public async Task<CreateSaleResponse> Post([FromBody] CreateSaleRequest req)
        {
            var aIds = req.Details.Select(x => x.ArticleId).Distinct().ToList();
            var prices = await _uow.Articles.GetPricesByIds(aIds);
            if (prices.Count != aIds.Count)
            {
                throw new ConflictException("Alguno de los articulos no existe");
            }
            Sale sale = new Sale()
            {
                ClientId = req.ClientId,
                Date = DateTime.UtcNow,
                InvoiceType = req.InvoiceType,
                
                Discount = req.Discount,
                Details = new List<SaleDetail>(),
                CreatedBy = "x",
                CreatedAt = DateTime.UtcNow,
                UpdatedBy = "x",
                UpdatedAt = DateTime.UtcNow,
            };

            foreach(var dto in req.Details){
                var newDetail = new SaleDetail
                {
                    ArticleId = dto.ArticleId,
                    Quantity = dto.Quantity,
                    UnitPrice = prices[dto.ArticleId],
                    Discount = dto.Discount
                };
                sale.SubTotal += newDetail.Total;
                sale.Details.Add(newDetail);
                Debug.WriteLine($"precio unitario: {newDetail.UnitPrice} ");
            }
            await _uow.Sales.AddAsync(sale);
            await _uow.SaveChangesAsync();
            CreateSaleResponse saleResponse = new CreateSaleResponse() {
                Id = sale.Id,
                ClientId = sale.ClientId,
                Date = sale.Date,
                InvoiceType = sale.InvoiceType,
                SubTotal = sale.SubTotal,
                Discount = sale.Discount,
                Total = sale.Total,
                Details = sale.Details.Select(detail => new CreateSaleDetailResponse
                {
                    ArticleId = detail.ArticleId,
                    Quantity = detail.Quantity,
                    Discount = detail.Discount,
                    SubTotal = detail.SubTotal,
                    Total = detail.Total,
                    UnitPrice = detail.UnitPrice
                }).ToList()
            };
            return saleResponse;
        }
    }
}
