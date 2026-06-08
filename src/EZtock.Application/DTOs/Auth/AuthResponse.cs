using EZtock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.Auth
{
    public class AuthResponse
    {
        public string FullName { get; set; }
        public string Dni { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
