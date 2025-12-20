using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Context;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using Microsoft.EntityFrameworkCore; // Konieczne dla metody .Include()

namespace GancewskaKerebinska.CeramicsCatalogue.DAO.Repositories
{
    public class CeramicRepositoryEf : ICeramicRepository
    {
        public IEnumerable<ICeramicItem> GetAll()
        {
            using var ctx = new CeramicsDbContext();
            return ctx.CeramicItems
                .Include(x => x.Producer) 
                .ToList();
        }
        public IEnumerable<ICeramicItem> Search(string query)
        {
            using var ctx = new CeramicsDbContext();
            
            if (string.IsNullOrWhiteSpace(query))
                return GetAll();

            var normalizedQuery = query.ToLower();

            return ctx.CeramicItems
                .Include(x => x.Producer)
                .Where(x => x.Name.ToLower().Contains(normalizedQuery))
                .ToList();
        }

        public void Add(ICeramicItem item)
        {
            using var ctx = new CeramicsDbContext();
            ctx.CeramicItems.Add((CeramicItemDo)item);
            ctx.SaveChanges();
        }

        public void Update(ICeramicItem item)
        {
            using var ctx = new CeramicsDbContext();
            ctx.CeramicItems.Update((CeramicItemDo)item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            using var ctx = new CeramicsDbContext();
            var item = ctx.CeramicItems.Find(id);
            if (item != null)
            {
                ctx.CeramicItems.Remove(item);
                ctx.SaveChanges();
            }
        }
    }
}