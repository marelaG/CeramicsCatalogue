using Interfaces.Entities;

namespace Interfaces.Repositories;

public interface ICeramicRepository
{
    IEnumerable<ICeramicItem> GetAll();
    void Add(ICeramicItem item);
    void Update(ICeramicItem item);
    void Delete(int id);
}