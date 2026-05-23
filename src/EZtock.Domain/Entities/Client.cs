using EZtock.Domain.Common;
using EZtock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public ClientType Type { get; set; }
        public string Dni { get; set; }
        public string Cuit { get; set; }
        public string Description { get; set; }
        public CondIva CondIva { get; set; }
        public string Address { get; set; }
        public Guid ProvinceId { get; set; }
        public Province Province { get; set; }
        public Guid ZoneId { get; set; }
        public Zone Zone { get; set; }
        public int PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RazonSocial { get; set; }

    }
}
