using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.DAOMock.Entities
{
    public class CeramicItemMock : ICeramicItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public CeramicType CeramicType { get; set; }
        public FiringType FiringType { get; set; }
        public int ProducerId { get; set; }
        
        public IProducer? Producer { get; set; }
        
        IProducer ICeramicItem.Producer => Producer!;
    }
}