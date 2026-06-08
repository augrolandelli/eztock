using EZtock.Application.DTOs.Simples;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork _uow;
        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        
        [HttpPost]
        public async Task<Category> Post([FromBody] SimpleCreateRequest request)
        {
            Category cat = new Category()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedBy = "web",
                CreatedAt =DateTime.UtcNow,
                UpdatedBy = "web",
                UpdatedAt = DateTime.UtcNow
            };
            await _uow.Categories.AddAsync(cat);
            await _uow.SaveChangesAsync();
            return cat;

        }
    }
}
