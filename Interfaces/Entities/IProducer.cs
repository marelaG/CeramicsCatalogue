using Core.Enums;

namespace Interfaces.Entities;

public interface IProducer
{
    int Id { get; }
    string Name { get; set; }
    Country Country { get; set; }
}