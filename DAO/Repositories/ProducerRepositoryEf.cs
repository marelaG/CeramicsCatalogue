using GancewskaKerebinska.CeramicsCatalogue.DAO.Context;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

namespace GancewskaKerebinska.CeramicsCatalogue.DAO.Repositories{
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
            var newProducer = new ProducerDo
            {
                Name = producer.Name,
                Country = producer.Country
            };
            context.Producers.Add(newProducer);
            context.SaveChanges();
        }

        public void Update(IProducer producer)
        {
            using var context = new CeramicsDbContext();
            var existingProducer = context.Producers.Find(producer.Id);
            if (existingProducer != null)
            {
                existingProducer.Name = producer.Name;
                existingProducer.Country = producer.Country;
                context.SaveChanges();
            }
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