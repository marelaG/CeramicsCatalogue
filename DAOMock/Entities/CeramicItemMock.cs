using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.DAOMock.Entities
{
    public class CeramicItemMock : ICeramicItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public CeramicType CeramicType { get; set; }
        public FiringType FiringType { get; set; }
        public int ProducerId { get; set; }
        
        // In a mock, we might not have navigation properties automatically populated like EF,
        // but we can simulate it or just return null if not manually set.
        // For simplicity, we'll allow setting it.
        public IProducer? Producer { get; set; }
        
        // Explicit interface implementation to satisfy ICeramicItem which expects non-nullable IProducer (if that's the contract)
        // However, if the interface allows nulls, we should update the interface. 
        // Assuming the interface expects a producer, but in mock it might be temporarily null.
        // Let's use null-forgiving for the interface property if we can't change the interface right now,
        // or better, ensure it's populated.
        IProducer ICeramicItem.Producer => Producer!;
    }
}