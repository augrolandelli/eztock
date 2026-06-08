using EZtock.Application.DTOs.Auth;
using EZtock.Application.Exceptions;
using EZtock.Application.Interfaces;
using EZtock.Domain.Entities;
using EZtock.Domain.Enums;
using EZtock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace EZtock.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _uow;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(IJwtService jwtService, IPasswordHasher passwordHasher, IUnitOfWork uow)
        {
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
            _uow = uow;
        }
        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var exist = await _uow.Users.GetByEmailAsync( request.Email );
            if (exist != null) {
                throw new ConflictException("Email ya registrado.");
            }
            User user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Dni = request.Dni,
                Email =request.Email,
                Phone = request.Phone,
                UserName = request.Dni,
                PasswordHashed = _passwordHasher.Hash(request.Password),
                Role = request.Role,
                CreatedBy = "Web",
                CreatedAt = DateTime.UtcNow,
                UpdatedBy = "",
                UpdatedAt = DateTime.UtcNow
            };
            AuthResponse response = new AuthResponse
            {
                FullName = request.FullName,
                Dni = request.Dni,
                Token = _jwtService.GenerateToken(user),
                Role = user.Role.ToString()
            };
            await _uow.Users.AddAsync(user);
            await _uow.SaveChangesAsync();
            return response;
        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var exist = await _uow.Users.GetByEmailAsync(request.Email);
            
            if (exist == null)
            {
                throw new UnauthorizedException("Usuario no encontrado.");
            }
            if(! _passwordHasher.Verify(request.Password, exist.PasswordHashed))
            {
                throw new UnauthorizedException("Credenciales invalidas.");
            }
            AuthResponse response = new AuthResponse
            {
                FullName = exist.FullName,
                Dni = exist.Dni,
                Token = _jwtService.GenerateToken(exist),
                Role = exist.Role.ToString()
            };
            return response;
        }
    }
}
