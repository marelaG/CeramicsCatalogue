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
                .Where(x => x.Name.ToLower().Contains(normalizedQuery) || 
                            (x.Description != null && x.Description.ToLower().Contains(normalizedQuery)))
                .ToList();
        }

        public IEnumerable<ICeramicItem> GetByProducer(int producerId)
        {
            using var ctx = new CeramicsDbContext();
            return ctx.CeramicItems
                .Include(x => x.Producer)
                .Where(x => x.ProducerId == producerId)
                .ToList();
        }

        public void Add(ICeramicItem item)
        {
            using var ctx = new CeramicsDbContext();
            var newItem = new CeramicItemDo
            {
                Name = item.Name,
                ImagePath = item.ImagePath,
                Description = item.Description,
                CeramicType = item.CeramicType,
                FiringType = item.FiringType,
                ProducerId = item.ProducerId
            };
            ctx.CeramicItems.Add(newItem);
            ctx.SaveChanges();
        }

        public void Update(ICeramicItem item)
        {
            using var ctx = new CeramicsDbContext();
            var existingItem = ctx.CeramicItems.Find(item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.ImagePath = item.ImagePath;
                existingItem.Description = item.Description;
                existingItem.CeramicType = item.CeramicType;
                existingItem.FiringType = item.FiringType;
                existingItem.ProducerId = item.ProducerId;
                ctx.SaveChanges();
            }
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