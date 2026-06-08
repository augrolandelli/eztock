using EZtock.Application.DTOs.Simples;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public BrandController(IUnitOfWork uow)
        {
            _uow = uow;

        }
        [HttpPost]
        public async Task<Brand> Post([FromBody] SimpleCreateRequest request)
        {
            Brand brand = new Brand()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "x",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "x",
            };
            await _uow.Brands.AddAsync(brand);
            await _uow.SaveChangesAsync();
            return brand;
        }
    }
}
