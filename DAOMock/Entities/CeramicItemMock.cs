using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.DAOMock.Entities
{
    public class CeramicItemMock : ICeramicItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }
        public CeramicType CeramicType { get; set; }
        public FiringType FiringType { get; set; }
        public int ProducerId { get; set; }
        
        // In a mock, we might not have navigation properties automatically populated like EF,
        // but we can simulate it or just return null if not manually set.
        // For simplicity, we'll allow setting it.
        public IProducer Producer { get; set; }
    }
}