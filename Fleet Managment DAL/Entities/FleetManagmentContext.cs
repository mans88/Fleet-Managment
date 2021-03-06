﻿using Microsoft.EntityFrameworkCore;

namespace Fleet_Managment_DAL.Entities
{
    public partial class FleetManagmentContext : DbContext
    {
        public FleetManagmentContext()
        {
        }

        public FleetManagmentContext(DbContextOptions<FleetManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<ModelFuel> ModelFuels { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<TechnicalControl> TechnicalControls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Fleet Managment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelFuel>().HasKey(sc => new { sc.ModelId, sc.FuelId });
        }
    }
}