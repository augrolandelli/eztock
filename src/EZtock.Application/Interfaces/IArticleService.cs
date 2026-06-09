using EZtock.Application.DTOs.Articles;
using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.Interfaces
{
    public interface IArticleService
    {
        Task<Article> CreateArticleAsync(CreateArticleRequest request); 
    }
}
