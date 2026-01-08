using System.Windows.Input;
using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Commands;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ProductEditorViewModel : ViewModelBase
    {
        private readonly ICeramicItem _item;

        public string Name
        {
            get => _item.Name;
            set
            {
                _item.Name = value;
                OnPropertyChanged();
            }
        }

        public string? Description
        {
            get => _item.Description;
            set
            {
                _item.Description = value;
                OnPropertyChanged();
            }
        }

        public string? ImagePath
        {
            get => _item.ImagePath;
            set
            {
                _item.ImagePath = value;
                OnPropertyChanged();
            }
        }

        public CeramicType CeramicType
        {
            get => _item.CeramicType;
            set
            {
                _item.CeramicType = value;
                OnPropertyChanged();
            }
        }

        public FiringType FiringType
        {
            get => _item.FiringType;
            set
            {
                _item.FiringType = value;
                OnPropertyChanged();
            }
        }

        public IProducer? SelectedProducer
        {
            get => Producers.FirstOrDefault(p => p.Id == _item.ProducerId);
            set
            {
                if (value != null)
                {
                    _item.ProducerId = value.Id;
                    OnPropertyChanged();
                }
            }
        }

        public IEnumerable<IProducer> Producers { get; }
        public IEnumerable<CeramicType> CeramicTypes => Enum.GetValues(typeof(CeramicType)).Cast<CeramicType>();
        public IEnumerable<FiringType> FiringTypes => Enum.GetValues(typeof(FiringType)).Cast<FiringType>();

        public ProductEditorViewModel(ICeramicItem item, IEnumerable<IProducer> producers)
        {
            _item = item;
            Producers = producers;
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
            if (propertyName == nameof(SelectedProducer))
            {
                if (SelectedProducer == null)
                    return "Producer is required.";
            }
            return null;
        }
        
        public override bool IsValid => string.IsNullOrEmpty(GetValidationError(nameof(Name))) && SelectedProducer != null;
    }
}