using Core.Enums;
namespace Interfaces.Entities;

public interface ICeramicItem
{
    int Id { get; }
    string Name { get; set; }
    CeramicType CeramicType { get; set; }
    FiringType FiringType { get; set; }
    int ProducerId { get; set; }
}