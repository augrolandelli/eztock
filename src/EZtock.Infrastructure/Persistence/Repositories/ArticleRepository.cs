using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Infrastructure.Persistence.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly AppDbContext _context;
        public ArticleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Article?> GetByCodeAsync(string code)
        {
            return await _context.Articles.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<Article?> Exist(string code, string name, string plu)
        {
            return await _context.Articles.FirstOrDefaultAsync(x=>x.Code == code || x.Name == name || x.Plu == plu);
        }

        public async Task<Dictionary<Guid, decimal>> GetPricesByIds(List<Guid> Ids)
        {
            return await _context.Articles
                .Where(a=>Ids.Contains(a.Id))
                .Select(a=> new {a.Id, a.SalePriceIva})
                .ToDictionaryAsync(a => a.Id, a => a.SalePriceIva);
        }
    }
}
