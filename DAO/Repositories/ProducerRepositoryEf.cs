using GancewskaKerebinska.CeramicsCatalogue.DAO.Context;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

namespace DAO.Repositories
{
    public class ProducerRepositoryEf : IProducerRepository
    {
        public IEnumerable<IProducer> GetAll()
        {
            using var context = new CeramicsDbContext();
            return context.Producers.ToList();
        }

        public void Add(IProducer producer)
        {
            using var context = new CeramicsDbContext();
            context.Producers.Add((ProducerDo)producer);
            context.SaveChanges();
        }

        public void Update(IProducer producer)
        {
            using var context = new CeramicsDbContext();
            context.Producers.Update((ProducerDo)producer);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new CeramicsDbContext();
            var producer = context.Producers.Find(id);

            if (producer != null)
            {
                context.Producers.Remove(producer);
                context.SaveChanges();
            }
        }
    }
}