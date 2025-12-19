using Interfaces.Entities;
using Interfaces.Repositories;

namespace BL.Services
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