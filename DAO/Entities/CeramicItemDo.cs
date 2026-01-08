using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.DAO.Entities
{
    public class CeramicItemDo : ICeramicItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public CeramicType CeramicType { get; set; }
        public FiringType FiringType { get; set; }

        public int ProducerId { get; set; }
        public ProducerDo Producer { get; set; } = null!;
        
        IProducer ICeramicItem.Producer => Producer;
    }
}