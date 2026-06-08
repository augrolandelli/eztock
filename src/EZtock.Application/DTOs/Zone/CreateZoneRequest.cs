using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.DTOs.Zone
{
    public class CreateZoneRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProvinceId { get; set; }
    }
}
