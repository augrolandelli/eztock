using EZtock.Application.DTOs.SubCategory;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public SubCategoryController(IUnitOfWork uow)
        {
            _uow = uow;

        }

        [HttpPost]
        public async Task<SubCategory> Post([FromBody] CreateSubCategoryRequest req)
        {
            SubCategory sc = new SubCategory()
            {
                Name = req.Name,
                Description = req.Description,
                CategoryId = req.CategoryId,
                CreatedBy ="x",
                CreatedAt = DateTime.UtcNow,
                UpdatedBy ="x",
                UpdatedAt = DateTime.UtcNow,
            };
            await _uow.SubCategories.AddAsync(sc);
            await _uow.SaveChangesAsync();
            return sc;
        }

    }
}
