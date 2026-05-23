using EZtock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleRepository Articles { get; }
        IBatchRepository Batches { get; }

        ITenantRepository Tenants { get; }
        IUserRepository Users { get; }
        IPurchaseRepository Purchases { get; }
        IPurchaseDetailRepository PurchaseDetail { get; }
        ISaleRepository Sales { get; }
        ISaleDetailRepository SaleDetails { get; }
        ISaleBatchAllocationRepository SaleBatchAllocation { get; }

        Task<int> SaveChangesAsync();
    }
}
