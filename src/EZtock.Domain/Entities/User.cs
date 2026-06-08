using EZtock.Domain.Common;
using EZtock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string FullName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string PasswordHashed { get; set; }
        public UserRole Role { get; set; }
    }
}
