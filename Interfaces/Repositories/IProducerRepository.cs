using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

public interface IProducerRepository
{
    IEnumerable<IProducer> GetAll();
    void Add(IProducer producer);
    void Update(IProducer producer);
    void Delete(int id);
}