using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Repositories
{
    public class SaleDetailRepository : GenericRepository<SaleDetail>, ISaleDetailRepository
    {
        private readonly AppDbContext _context;
        public SaleDetailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
