using EZtock.Application.DTOs.Client;
using EZtock.Application.Exceptions;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ClientController(IUnitOfWork uow)
        {
            _uow = uow;

        }

        [HttpPost]
        public async Task<Client> Post([FromBody] CreateClientRequest req)
        {
            var province = await _uow.Provinces.GetByIdAsync(req.ProvinceId);
            if(province == null)
            {
                throw new ConflictException("Provincia no encontrada.");
            }
            var zone = await _uow.Zones.GetByIdAsync(req.ZoneId);
            if (zone == null)
            {
                throw new ConflictException("Zona no encontrada.");
            }
            Client c = new Client()
            {
                FullName = req.FullName,
                Type = req.Type,
                Dni = req.Dni,
                Cuit = req.Cuit,
                Description = req.Description,
                CondIva = req.CondIva,
                Address = req.Address,
                ProvinceId = req.ProvinceId,
                Province = province,
                ZoneId = req.ZoneId,
                Zone = zone,
                PostalCode = req.PostalCode,
                Email = req.Email,
                Phone = req.Phone,
                RazonSocial = req.RazonSocial,
                CreatedBy = "x",
                CreatedAt = DateTime.UtcNow,
                UpdatedBy = "x",
                UpdatedAt = DateTime.UtcNow,
            };
            await _uow.Clients.AddAsync(c);
            await _uow.SaveChangesAsync();
            return c;
        }
    }
}
