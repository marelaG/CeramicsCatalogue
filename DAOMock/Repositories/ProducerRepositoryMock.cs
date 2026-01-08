using GancewskaKerebinska.CeramicsCatalogue.DAOMock.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

namespace GancewskaKerebinska.CeramicsCatalogue.DAOMock.Repositories
{
    public class ProducerRepositoryMock : IProducerRepository
    {
        private static readonly List<IProducer> _producers = new List<IProducer>();
        private static int _nextId = 1;

        public IEnumerable<IProducer> GetAll()
        {
            return _producers.ToList();
        }

        public void Add(IProducer producer)
        {
            var mock = (ProducerMock)producer;
            mock.Id = _nextId++;
            _producers.Add(mock);
        }

        public void Update(IProducer producer)
        {
            var existing = _producers.FirstOrDefault(p => p.Id == producer.Id);
            if (existing != null)
            {
                existing.Name = producer.Name;
                existing.Country = producer.Country;
            }
        }

        public void Delete(int id)
        {
            var existing = _producers.FirstOrDefault(p => p.Id == id);
            if (existing != null)
            {
                _producers.Remove(existing);
            }
        }
    }
}