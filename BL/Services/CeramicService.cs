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

        public void Add(ICeramicItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Name) || item.Name.Length < 3)
                throw new Exception("Name must be at least 3 characters long");

            _repository.Add(item);
        }
    }
}