using EZtock.Application.DTOs.Articles;
using EZtock.Application.Exceptions;
using EZtock.Application.Interfaces;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateArticleRequest req)
        {
            await _articleService.CreateArticleAsync(req);
            return Ok("Articulo creado!");

        }
    }
}
