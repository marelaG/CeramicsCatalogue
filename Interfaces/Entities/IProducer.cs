using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;

namespace GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

public interface IProducer
{
    int Id { get; }
    string Name { get; set; }
    Country Country { get; set; }
}