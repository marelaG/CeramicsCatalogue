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
                new ProducerDo { Id = 2, Name = "Royal Copenhagen", Country = Country.Other }
            );

            modelBuilder.Entity<CeramicItemDo>().HasData(
                new CeramicItemDo { Id = 1, Name = "Mug", ImagePath = null, CeramicType = CeramicType.Mug, FiringType = FiringType.Porcelain, ProducerId = 1 },
                new CeramicItemDo { Id = 2, Name = "Plate", ImagePath = null, CeramicType = CeramicType.Plate, FiringType = FiringType.Stoneware, ProducerId = 1 },
                new CeramicItemDo { Id = 3, Name = "Vase", ImagePath = null, CeramicType = CeramicType.Vase, FiringType = FiringType.Earthenware, ProducerId = 2 }
            );
        }
    }
}