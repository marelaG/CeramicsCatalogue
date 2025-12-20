using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

public interface ICeramicRepository
{
    IEnumerable<ICeramicItem> GetAll();
    IEnumerable<ICeramicItem> Search(string query);
    void Add(ICeramicItem item);
    void Update(ICeramicItem item);
    void Delete(int id);
}