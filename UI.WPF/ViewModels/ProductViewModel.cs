using System.Collections.ObjectModel;
using System.ComponentModel;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly ICeramicRepository _ceramicRepository;
        private ICeramicItem _selectedProduct;
        public ObservableCollection<ICeramicItem> Products { get; set; }

        public ICeramicItem SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            _ceramicRepository = Bootstrapper.CreateCeramicRepository();
            Products = new ObservableCollection<ICeramicItem>(_ceramicRepository.GetAll());
        }
    }
}