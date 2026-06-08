using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Repositories
{
    public class SaleBatchAllocationRepository : GenericRepository<SaleBatchAllocation>, ISaleBatchAllocationRepository
    {
        private readonly AppDbContext _context;
        public SaleBatchAllocationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
