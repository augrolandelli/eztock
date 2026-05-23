using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Interfaces
{
    public interface IArticleRepository : IRepository<Article> 
    {
        Task<Article?> GetByCodeAsync(string code);
    }
}
