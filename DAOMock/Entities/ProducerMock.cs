using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.DAOMock.Entities
{
    public class ProducerMock : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}