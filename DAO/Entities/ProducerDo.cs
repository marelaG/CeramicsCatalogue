using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.DAO.Entities
{
    public class ProducerDo : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Country Country { get; set; }

        public ICollection<CeramicItemDo> CeramicItems { get; set; } = new List<CeramicItemDo>();
    }
}