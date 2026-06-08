using EZtock.Application.DTOs.Simples;
using EZtock.Application.DTOs.Zone;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ZoneController(IUnitOfWork uow)
        {
            _uow = uow;

        }

        [HttpPost]
        public async Task<Zone> Post([FromBody] CreateZoneRequest request)
        {
            Zone z = new Zone()
            {
                Name = request.Name,
                Description = request.Description,
                ProvinceId = request.ProvinceId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "x",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "x",
            };
            await _uow.Zones.AddAsync(z);
            await _uow.SaveChangesAsync();
            return z;
        } 
    }
}
