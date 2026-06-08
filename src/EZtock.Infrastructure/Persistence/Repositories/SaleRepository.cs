using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly AppDbContext _context;
        public SaleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
