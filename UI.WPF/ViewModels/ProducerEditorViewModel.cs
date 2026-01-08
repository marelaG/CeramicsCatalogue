using System.Windows.Input;
using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Commands;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ProducerEditorViewModel : ViewModelBase
    {
        private readonly IProducer _producer;

        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                OnPropertyChanged();
            }
        }

        public Country Country
        {
            get => _producer.Country;
            set
            {
                _producer.Country = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Country> Countries => Enum.GetValues(typeof(Country)).Cast<Country>();

        public ProducerEditorViewModel(IProducer producer)
        {
            _producer = producer;
        }

        protected override string? GetValidationError(string propertyName)
        {
            if (propertyName == nameof(Name))
            {
                if (string.IsNullOrWhiteSpace(Name))
                    return "Name is required.";
                if (Name.Length < 3)
                    return "Name must be at least 3 characters.";
            }
            return null;
        }
        
        public override bool IsValid => string.IsNullOrEmpty(GetValidationError(nameof(Name)));
    }
}