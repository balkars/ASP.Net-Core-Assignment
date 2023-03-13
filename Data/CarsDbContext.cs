using CarSales.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarSales.Data
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Model> Models { get; set; }
        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(vf => new { vf.VehicleId, vf.FeatureId });
        }
       
    }
}
