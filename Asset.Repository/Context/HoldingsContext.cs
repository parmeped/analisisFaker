using Microsoft.EntityFrameworkCore;
using Faker.Domain;

namespace Assets.Repository.Context
{
    public class HoldingsContext : DbContext
    {
        public HoldingsContext(DbContextOptions<HoldingsContext> options) : base(options) { }
        
        public DbSet<DimDate> DimDate { get; set; }
        public DbSet<DimGeography> DimGeography { get; set; }
        public DbSet<DimHospital> DimHospitals { get; set; }
        public DbSet<DimIndividual> DimIndividual { get; set; }
        public DbSet<DimVaccines> DimVaccines { get; set; }
        public DbSet<FactDistribution> FactDistribution { get; set; }
    }
}
