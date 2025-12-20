using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

public interface ICeramicRepository
{
    IEnumerable<ICeramicItem> GetAll();
    IEnumerable<ICeramicItem> Search(string query);
    IEnumerable<ICeramicItem> GetByProducer(int producerId);
    void Add(ICeramicItem item);
    void Update(ICeramicItem item);
    void Delete(int id);
}