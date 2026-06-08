using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Repositories
{
    public class PurchaseDetailRepository : GenericRepository<PurchaseDetail>, IPurchaseDetailRepository
    {
        private readonly AppDbContext _context;
        public PurchaseDetailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
