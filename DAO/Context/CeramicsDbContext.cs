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
                new CeramicItemDo { Id = 1, Name = "Mug", ImagePath = "https://manufakturawboleslawcu.com/cdn/shop/files/IMG_3976_600x.jpg?v=1711186133", Description = "Classic mug", CeramicType = CeramicType.Mug, FiringType = FiringType.Porcelain, ProducerId = 1 },
                new CeramicItemDo { Id = 2, Name = "Plate", ImagePath = "https://uniceramic.pl/wp-content/uploads/2024/03/Talerz-talerz-obiadowy-talerz-na-ciasto-talerzyk-deserowy-ceramika-boleslawiec-porcelana-boleslawiec-ceramika-boleslawiec-sklep-internetowy-zaklady-boleslawiec-boleslawiec-e-manufaktura-manufaktura-07.jpg", Description = "Dinner plate", CeramicType = CeramicType.Plate, FiringType = FiringType.Stoneware, ProducerId = 1 },
                new CeramicItemDo { Id = 3, Name = "Vase", ImagePath = "https://di2ponv0v5otw.cloudfront.net/posts/2024/12/08/67566fc56cb777d932032942/m_675670c9c9af8c3c0a0355af.jpeg", Description = "Decorative vase", CeramicType = CeramicType.Vase, FiringType = FiringType.Earthenware, ProducerId = 2 },
                new CeramicItemDo { Id = 4, Name = "Blue Fluted Plain Plate", ImagePath = "https://marymahoney.com/cdn/shop/products/4307cdb25d52ae0152f17c528103a853_6088b499-3c40-4a61-8b57-680681a50eed_1440x.jpg?v=1635753875", Description = "Hand painted", CeramicType = CeramicType.Plate, FiringType = FiringType.Porcelain, ProducerId = 2 },
                new CeramicItemDo { Id = 5, Name = "Onion Pattern Bowl", ImagePath = "https://cdn20.pamono.com/p/g/1/0/1094851_7uuqld5vmu/mid-century-blue-onion-pattern-large-bowl-from-meissen-stadt-1.jpg", Description = "Traditional pattern", CeramicType = CeramicType.Bowl, FiringType = FiringType.Porcelain, ProducerId = 3 },
                new CeramicItemDo { Id = 6, Name = "Jasperware Vase", ImagePath = "https://halls.blob.core.windows.net/stock/108041-0-medium.jpg?v=63691023749127", Description = "Iconic blue", CeramicType = CeramicType.Vase, FiringType = FiringType.Stoneware, ProducerId = 4 }
            );
        }
    }
}