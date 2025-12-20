using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
namespace GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

public interface ICeramicItem
{
    int Id { get; }
    string Name { get; set; }
    CeramicType CeramicType { get; set; }
    FiringType FiringType { get; set; }
    int ProducerId { get; set; }
    IProducer Producer { get; }
}