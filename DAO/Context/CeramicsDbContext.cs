using Microsoft.EntityFrameworkCore;
using DAO.Entities;

namespace DAO.Context
{
    public class CeramicsDbContext : DbContext
    {
        public DbSet<CeramicItemDo> CeramicItems { get; set; }
        public DbSet<ProducerDo> Producers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=ceramics.db");
        }
    }
}