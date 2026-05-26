using EZtock.Domain.Entities;
using EZtock.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EZtock.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentTenant _currentTenant;
        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentTenant currentTenant) : base(options)
        {
            _currentTenant = currentTenant;
        }
        
        public DbSet<Article> Articles { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Expiration> Expirations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleBatchAllocation> SaleBatchAllocations { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubscriptionFeature> SubscriptionFeatures { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Zone> Zones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(_currentTenant.SchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
