using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

namespace GancewskaKerebinska.CeramicsCatalogue.BL.Services
{
    public class ProducerService
    {
        private readonly IProducerRepository _repository;

        public ProducerService(IProducerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IProducer> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<IProducer> Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return GetAll();

            return _repository.GetAll()
                .Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<IProducer> GetByCountry(Country country)
        {
            return _repository.GetAll()
                .Where(p => p.Country == country);
        }

        public IEnumerable<Country> GetAvailableCountries()
        {
            return _repository.GetAll()
                .Select(p => p.Country)
                .Distinct()
                .OrderBy(c => c);
        }

        public void Add(IProducer producer)
        {
            ValidateProducer(producer);
            _repository.Add(producer);
        }

        public void Update(IProducer producer)
        {
            ValidateProducer(producer);
            _repository.Update(producer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        private void ValidateProducer(IProducer producer)
        {
            if (producer == null)
                throw new ArgumentNullException(nameof(producer));

            if (string.IsNullOrWhiteSpace(producer.Name))
                throw new Exception("Producer name cannot be empty");

            if (producer.Name.Length < 3)
                throw new Exception("Producer name must be at least 3 characters long");
        }
    }
}
