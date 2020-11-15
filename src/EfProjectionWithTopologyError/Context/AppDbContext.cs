using EfProjectionWithTopologyError.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfProjectionWithTopologyError.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<HealthInstitution> HealthInstitutions { get; set; }
        public DbSet<MedicalService> MedicalServices { get; set; }
        public DbSet<HealthInstitutionMedicalServiceLink> HealthInstitutionMedicalServiceLinks { get; set; }
    }
}
