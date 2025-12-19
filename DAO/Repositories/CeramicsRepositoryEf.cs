using Interfaces.Repositories;
using Interfaces.Entities;
using DAO.Context;

namespace DAO.Repositories
{
    public class CeramicRepositoryEf : ICeramicRepository
    {
        public IEnumerable<ICeramicItem> GetAll()
        {
            using var ctx = new CeramicsDbContext();
            return ctx.CeramicItems.ToList();
        }

        public void Add(ICeramicItem item)
        {
            using var ctx = new CeramicsDbContext();
            ctx.CeramicItems.Add((Entities.CeramicItemDo)item);
            ctx.SaveChanges();
        }

        public void Update(ICeramicItem item)
        {
            using var ctx = new CeramicsDbContext();
            ctx.CeramicItems.Update((Entities.CeramicItemDo)item);
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