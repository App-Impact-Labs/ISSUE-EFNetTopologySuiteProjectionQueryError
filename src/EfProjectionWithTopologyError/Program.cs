using EfProjectionWithTopologyError.Context;
using EfProjectionWithTopologyError.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfProjectionWithTopologyError
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDesignTimeDbContextFactory dbContextFactory = new AppDesignTimeDbContextFactory();

            using AppDbContext dbContext = dbContextFactory.CreateDbContext();

            dbContext.Database.Migrate();

            var dto = dbContext.HealthInstitutions
                .Select(hi => new HealthInstitutionGetDetailsRes
                {
                    Id = hi.Id,
                    Name = hi.Name,
                    Coordinates = new HealthInstitutionGetDetailsRes.GeolocationDto 
                    {
                        Latitude = hi.Coordinates.Y,
                        Longitude = hi.Coordinates.X
                    },
                    MedicalServiceIds = hi.MedicalServiceLinks.Select(msl => msl.MedicalServiceId)
                })
                .FirstOrDefault();

            Console.WriteLine("Completed!");
            Console.ReadLine();
        }
    }
}
