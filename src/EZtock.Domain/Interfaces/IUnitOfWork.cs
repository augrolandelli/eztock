using System.Threading.Tasks;

namespace EZtock.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleRepository Articles { get; }
        IBatchRepository Batches { get; }
        IUserRepository Users { get; }
        IBrandRepository Brands { get; }
        IZoneRepository Zones { get; }
        IProvinceRepository Provinces { get; }
        ICategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        IClientRepository Clients { get; }
        IPurchaseRepository Purchases { get; }
        IPurchaseDetailRepository PurchaseDetails { get; }
        ISaleRepository Sales { get; }
        ISaleDetailRepository SaleDetails { get; }
        ISaleBatchAllocationRepository SaleBatchAllocations { get; }
        Task<int> SaveChangesAsync();
    }
}
