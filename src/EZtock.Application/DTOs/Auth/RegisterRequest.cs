using EZtock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        public string FullName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
