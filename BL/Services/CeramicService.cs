using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.BL.Services
{
    public class CeramicService
    {
        private readonly ICeramicRepository _repository;

        public CeramicService(ICeramicRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ICeramicItem> GetAll() => _repository.GetAll();

        public IEnumerable<ICeramicItem> Search(string text) => _repository.Search(text);

        public void Add(ICeramicItem item)
        {
            ValidateItem(item);
            _repository.Add(item);
        }

        public void Update(ICeramicItem item)
        {
            ValidateItem(item);
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        private void ValidateItem(ICeramicItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Name) || item.Name.Length < 3)
                throw new Exception("Name must be at least 3 characters long");
            
            if (item.ProducerId <= 0)
                throw new Exception("Product must have a valid Producer");
        }
    }
}