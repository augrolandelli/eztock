using EZtock.Application.DTOs.Articles;
using EZtock.Application.Exceptions;
using EZtock.Application.Interfaces;
using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _uow;
        public ArticleService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Article> CreateArticleAsync(CreateArticleRequest req)
        {
            var brand = await _uow.Brands.GetByIdAsync(req.BrandId);
            var provider = await _uow.Clients.GetByIdAsync(req.ProviderId);
            var category = await _uow.Categories.GetByIdAsync(req.CategoryId);
            var subCategory = await _uow.SubCategories.GetByIdAsync(req.SubCategoryId);
            if (brand == null)
            {
                throw new ConflictException("Marca no encontrada.");
            }
            if (provider == null)
            {
                throw new ConflictException("Proveedor no encontrado.");
            }
            if (category == null)
            {
                throw new ConflictException("Categoria no encontrada.");
            }
            if (subCategory == null)
            {
                throw new ConflictException("Subcategoria no encontrada.");
            }
            var exist = await _uow.Articles.Exist(req.Code, req.Name, req.Plu);
            if (exist != null)
            {
                throw new ConflictException("Ya existe este articulo!");
            }
            Article a = new Article()
            {
                Code = req.Code,
                Name = req.Name,
                Description = req.Description,
                BrandId = req.BrandId,
                ProviderId = req.ProviderId,
                CategoryId = req.CategoryId,
                SubCategoryId = req.SubCategoryId,
                Weighable = req.Weighable,
                Plu = req.Plu,
                Stock = req.Stock,
                StockMin = req.StockMin,
                CostPrice = req.CostPrice,
                SalePrice = req.SalePrice,
                Iva = req.Iva,
                CostPriceIva = req.CostPriceIva,
                IsPublic = req.IsPublic,
                CreatedBy = "x",
                CreatedAt = DateTime.UtcNow,
                UpdatedBy = "x",
                UpdatedAt = DateTime.UtcNow

            };
            await _uow.Articles.AddAsync(a);
            await _uow.SaveChangesAsync();
            return a;
        }
    }
}
