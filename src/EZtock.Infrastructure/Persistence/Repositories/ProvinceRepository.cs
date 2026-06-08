using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Repositories
{
    public class ProvinceRepository : GenericRepository<Province>, IProvinceRepository
    {
        private readonly AppDbContext _context;
        public ProvinceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
