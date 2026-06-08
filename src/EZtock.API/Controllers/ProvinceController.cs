using EZtock.Application.DTOs.Simples;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ProvinceController(IUnitOfWork uow)
        {
            _uow = uow;

        }

        [HttpPost]
        public async Task<Province> Post([FromBody] SimpleCreateRequest req)
        {
            Province p = new Province()
            {
                Name = req.Name,
                Description = req.Description,
                CreatedBy = "x",
                CreatedAt = DateTime.UtcNow,
                UpdatedBy = "x",
                UpdatedAt = DateTime.UtcNow
            };
            await _uow.Provinces.AddAsync(p);
            await _uow.SaveChangesAsync();
            return p;
        }
    }
}
