using Microsoft.EntityFrameworkCore;
using Holdings.Domain.Filler;

namespace Assets.Repository.Context
{
    public class HoldingsContext : DbContext
    {
        public HoldingsContext(DbContextOptions<HoldingsContext> options) : base(options) { }
        
        public DbSet<DimCustomer> DimCustomer { get; set; }
        public DbSet<DimDate> DimDate { get; set; }
        public DbSet<DimGeography> DimGeography { get; set; }
        public DbSet<DimOrganization> DimOrganization { get; set; }
        public DbSet<DimProduct> DimProduct { get; set; }
        public DbSet<DimProductCategory> DimProductCategory { get; set; }
        public DbSet<DimProductSubcategory> DimProductSubcategory { get; set; }
        public DbSet<DimPromotion> DimPromotion { get; set; }
        public DbSet<FactSales> FactSales { get; set; }
    }
}
