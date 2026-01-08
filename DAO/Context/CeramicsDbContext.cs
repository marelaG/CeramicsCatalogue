using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;

namespace GancewskaKerebinska.CeramicsCatalogue.DAO.Context
{
    public class CeramicsDbContext : DbContext
    {
        public DbSet<CeramicItemDo> CeramicItems { get; set; }
        public DbSet<ProducerDo> Producers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=ceramics.db");
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProducerDo>().HasData(
                new ProducerDo { Id = 1, Name = "Bolesławiec", Country = Country.Poland },
                new ProducerDo { Id = 2, Name = "Royal Copenhagen", Country = Country.Other },
                new ProducerDo { Id = 3, Name = "Meissen", Country = Country.Germany },
                new ProducerDo { Id = 4, Name = "Wedgwood", Country = Country.UK }
            );

            modelBuilder.Entity<CeramicItemDo>().HasData(
                new CeramicItemDo { Id = 1, Name = "Mug", ImagePath = null, Description = "Classic mug", Price = 15.0, CeramicType = CeramicType.Mug, FiringType = FiringType.Porcelain, ProducerId = 1 },
                new CeramicItemDo { Id = 2, Name = "Plate", ImagePath = null, Description = "Dinner plate", Price = 20.0, CeramicType = CeramicType.Plate, FiringType = FiringType.Stoneware, ProducerId = 1 },
                new CeramicItemDo { Id = 3, Name = "Vase", ImagePath = null, Description = "Decorative vase", Price = 45.0, CeramicType = CeramicType.Vase, FiringType = FiringType.Earthenware, ProducerId = 2 },
                new CeramicItemDo { Id = 4, Name = "Blue Fluted Plain Plate", ImagePath = null, Description = "Hand painted", Price = 80.0, CeramicType = CeramicType.Plate, FiringType = FiringType.Porcelain, ProducerId = 2 },
                new CeramicItemDo { Id = 5, Name = "Onion Pattern Bowl", ImagePath = null, Description = "Traditional pattern", Price = 60.0, CeramicType = CeramicType.Bowl, FiringType = FiringType.Porcelain, ProducerId = 3 },
                new CeramicItemDo { Id = 6, Name = "Jasperware Vase", ImagePath = null, Description = "Iconic blue", Price = 120.0, CeramicType = CeramicType.Vase, FiringType = FiringType.Stoneware, ProducerId = 4 }
            );
        }
    }
}