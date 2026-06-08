using EZtock.Domain.Interfaces;
using EZtock.Infrastructure.Persistence.Repositories;

namespace EZtock.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IArticleRepository? _articles;
        private IBatchRepository? _batches;
        private IUserRepository? _users;
        private IBrandRepository? _brands;
        private IZoneRepository? _zones;
        private IClientRepository? _clients;
        private IProvinceRepository? _provinces;
        private ICategoryRepository? _categories;
        private ISubCategoryRepository? _subcategories;
        private IPurchaseRepository? _purchases;
        private IPurchaseDetailRepository? _purchaseDetails;
        private ISaleRepository? _sales;
        private ISaleDetailRepository? _saleDetails;
        private ISaleBatchAllocationRepository? _saleBatchAllocations;

        public IArticleRepository Articles => _articles ??= new ArticleRepository(_context);
        public IBrandRepository Brands => _brands ??= new BrandRepository(_context);
        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IZoneRepository Zones => _zones ??= new ZoneRepository(_context);
        public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);
        public ISubCategoryRepository SubCategories => _subcategories ??= new SubCategoryRepository(_context);
        public IProvinceRepository Provinces => _provinces ??= new ProvinceRepository(_context);
        public IClientRepository Clients => _clients ??= new ClientRepository(_context);
        public IBatchRepository Batches => _batches ??= new BatchRepository(_context);
        public IPurchaseRepository Purchases => _purchases ??= new PurchaseRepository(_context);
        public IPurchaseDetailRepository PurchaseDetails => _purchaseDetails ??= new PurchaseDetailRepository(_context);
        public ISaleRepository Sales => _sales ??= new SaleRepository(_context);
        public ISaleDetailRepository SaleDetails => _saleDetails ??= new SaleDetailRepository(_context);
        public ISaleBatchAllocationRepository SaleBatchAllocations => _saleBatchAllocations ??= new SaleBatchAllocationRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
