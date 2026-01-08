using GancewskaKerebinska.CeramicsCatalogue.DAOMock.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;
using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;

namespace GancewskaKerebinska.CeramicsCatalogue.DAOMock.Repositories
{
    public class CeramicRepositoryMock : ICeramicRepository
    {
        private static readonly List<ICeramicItem> _items = new List<ICeramicItem>();
        private static int _nextId = 1;
        
        // We need access to producers to simulate the join/navigation property
        private readonly ProducerRepositoryMock _producerRepo = new ProducerRepositoryMock();

        static CeramicRepositoryMock()
        {
            // Initialize with some mock data if empty
            if (!_items.Any())
            {
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Mug", Description = "Classic mug", Price = 15.0, CeramicType = CeramicType.Mug, FiringType = FiringType.Porcelain, ProducerId = 1 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Plate", Description = "Dinner plate", Price = 20.0, CeramicType = CeramicType.Plate, FiringType = FiringType.Stoneware, ProducerId = 1 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Vase", Description = "Decorative vase", Price = 45.0, CeramicType = CeramicType.Vase, FiringType = FiringType.Earthenware, ProducerId = 2 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Blue Fluted Plain Plate", Description = "Hand painted", Price = 80.0, CeramicType = CeramicType.Plate, FiringType = FiringType.Porcelain, ProducerId = 2 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Onion Pattern Bowl", Description = "Traditional pattern", Price = 60.0, CeramicType = CeramicType.Bowl, FiringType = FiringType.Porcelain, ProducerId = 3 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Jasperware Vase", Description = "Iconic blue", Price = 120.0, CeramicType = CeramicType.Vase, FiringType = FiringType.Stoneware, ProducerId = 4 });
            }
        }

        public IEnumerable<ICeramicItem> GetAll()
        {
            var items = _items.ToList();
            foreach (var item in items)
            {
                PopulateProducer(item);
            }
            return items;
        }

        public IEnumerable<ICeramicItem> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return GetAll();
            
            var items = _items.Where(x => x.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var item in items) PopulateProducer(item);
            return items;
        }

        public IEnumerable<ICeramicItem> GetByProducer(int producerId)
        {
            var items = _items.Where(x => x.ProducerId == producerId).ToList();
            foreach (var item in items) PopulateProducer(item);
            return items;
        }

        public void Add(ICeramicItem item)
        {
            var mock = (CeramicItemMock)item;
            mock.Id = _nextId++;
            _items.Add(mock);
        }

        public void Update(ICeramicItem item)
        {
            var existing = (CeramicItemMock?)_items.FirstOrDefault(x => x.Id == item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.ImagePath = item.ImagePath;
                existing.Description = item.Description;
                existing.Price = item.Price;
                existing.CeramicType = item.CeramicType;
                existing.FiringType = item.FiringType;
                existing.ProducerId = item.ProducerId;
            }
        }

        public void Delete(int id)
        {
            var existing = _items.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                _items.Remove(existing);
            }
        }

        private void PopulateProducer(ICeramicItem item)
        {
            if (item is CeramicItemMock mock)
            {
                mock.Producer = _producerRepo.GetAll().FirstOrDefault(p => p.Id == item.ProducerId);
            }
        }
    }
}