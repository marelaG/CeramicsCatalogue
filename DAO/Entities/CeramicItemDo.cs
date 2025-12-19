using Core.Enums;
using Interfaces.Entities;

namespace DAO.Entities
{
    public class CeramicItemDo : ICeramicItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CeramicType CeramicType { get; set; }
        public FiringType FiringType { get; set; }

        public int ProducerId { get; set; }
        public ProducerDo Producer { get; set; }
    }
}