using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Repositories
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        private readonly AppDbContext _context;
        public ZoneRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
