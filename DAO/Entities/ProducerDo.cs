using Core.Enums;
using Interfaces.Entities;

namespace DAO.Entities
{
    public class ProducerDo : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

        public ICollection<CeramicItemDo> CeramicItems { get; set; }
    }
}