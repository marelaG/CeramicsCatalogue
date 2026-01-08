using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
namespace GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

public interface ICeramicItem
{
    int Id { get; }
    string Name { get; set; }
    string? ImagePath { get; set; }
    string? Description { get; set; }
    CeramicType CeramicType { get; set; }
    FiringType FiringType { get; set; }
    int ProducerId { get; set; }
    IProducer Producer { get; }
}