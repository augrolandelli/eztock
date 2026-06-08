using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Repositories
{
    public class BatchRepository : GenericRepository<Batch>, IBatchRepository
    {
        private readonly AppDbContext _context;
        public BatchRepository(AppDbContext context) : base(context) {
            _context = context;
        }
        public async Task<IEnumerable<Batch>> GetActiveBatchesByArticleAsync(Guid id)
        {
            return await _context.Batches.Where(x => x.Id == id && x.IsActive == true).OrderBy(x => x.ExpirationDate).ToListAsync();
        }
    }
}
