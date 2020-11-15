using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EfProjectionWithTopologyError.Context
{
    public class AppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(params string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appSettings.json", false);

            IConfiguration configuration = configurationBuilder.Build();

            string connectionString = configuration.GetConnectionString(typeof(AppDbContext).Name);

            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(connectionString, sqlServerOptions =>
            {
                sqlServerOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                sqlServerOptions.UseNetTopologySuite();
            });

            optionsBuilder.EnableSensitiveDataLogging();

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
