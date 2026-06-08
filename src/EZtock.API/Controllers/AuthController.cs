using EZtock.Application.DTOs.Auth;
using EZtock.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZtock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) { 
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<AuthResponse> Register(RegisterRequest request)
        {
            return await _authService.RegisterAsync(request);
        }

        [HttpPost("login")]
        public async Task<AuthResponse> Login(LoginRequest request)
        {
            return await _authService.LoginAsync(request);
        }
    }
}
