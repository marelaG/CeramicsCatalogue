using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.Web.Models
{
    public class ProducerViewModel : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Country Country { get; set; }
    }
}
