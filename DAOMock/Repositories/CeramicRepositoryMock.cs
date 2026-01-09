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
        
        private readonly ProducerRepositoryMock _producerRepo = new ProducerRepositoryMock();

        static CeramicRepositoryMock()
        {
            if (!_items.Any())
            {
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "DAO MOCK MUG", ImagePath = "https://manufakturawboleslawcu.com/cdn/shop/files/IMG_3976_600x.jpg?v=1711186133", Description = "XXXXXX", CeramicType = CeramicType.Mug, FiringType = FiringType.Porcelain, ProducerId = 1 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Mug", ImagePath = "https://manufakturawboleslawcu.com/cdn/shop/files/IMG_3976_600x.jpg?v=1711186133", Description = "Classic mug", CeramicType = CeramicType.Mug, FiringType = FiringType.Porcelain, ProducerId = 1 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Plate", ImagePath = "https://uniceramic.pl/wp-content/uploads/2024/03/Talerz-talerz-obiadowy-talerz-na-ciasto-talerzyk-deserowy-ceramika-boleslawiec-porcelana-boleslawiec-ceramika-boleslawiec-sklep-internetowy-zaklady-boleslawiec-boleslawiec-e-manufaktura-manufaktura-07.jpg", Description = "Dinner plate", CeramicType = CeramicType.Plate, FiringType = FiringType.Stoneware, ProducerId = 1 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Vase", ImagePath = "https://di2ponv0v5otw.cloudfront.net/posts/2024/12/08/67566fc56cb777d932032942/m_675670c9c9af8c3c0a0355af.jpeg", Description = "Decorative vase", CeramicType = CeramicType.Vase, FiringType = FiringType.Earthenware, ProducerId = 2 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Blue Fluted Plain Plate", ImagePath = "https://marymahoney.com/cdn/shop/products/4307cdb25d52ae0152f17c528103a853_6088b499-3c40-4a61-8b57-680681a50eed_1440x.jpg?v=1635753875", Description = "Hand painted", CeramicType = CeramicType.Plate, FiringType = FiringType.Porcelain, ProducerId = 2 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Onion Pattern Bowl", ImagePath = "https://cdn20.pamono.com/p/g/1/0/1094851_7uuqld5vmu/mid-century-blue-onion-pattern-large-bowl-from-meissen-stadt-1.jpg", Description = "Traditional pattern", CeramicType = CeramicType.Bowl, FiringType = FiringType.Porcelain, ProducerId = 3 });
                _items.Add(new CeramicItemMock { Id = _nextId++, Name = "Jasperware Vase", ImagePath = "https://halls.blob.core.windows.net/stock/108041-0-medium.jpg?v=63691023749127", Description = "Iconic blue", CeramicType = CeramicType.Vase, FiringType = FiringType.Stoneware, ProducerId = 4 });
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