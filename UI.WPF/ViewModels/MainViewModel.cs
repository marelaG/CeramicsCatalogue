using System.Windows.Input;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Commands;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;
        private readonly ProductViewModel _productViewModel;
        private readonly ProducerViewModel _producerViewModel;
        private string _searchText = string.Empty;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                Search(null);
            }
        }

        public ICommand ChangeViewCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        public MainViewModel()
        {
            _productViewModel = new ProductViewModel();
            _producerViewModel = new ProducerViewModel();

            // Subscribe to producer changes
            _producerViewModel.ProducersChanged += OnProducersChanged;

            ChangeViewCommand = new RelayCommand(ChangeView);
            
            AddCommand = new RelayCommand(Add);
            ModifyCommand = new RelayCommand(Modify);
            DeleteCommand = new RelayCommand(Delete);
            SearchCommand = new RelayCommand(Search);

            _currentView = _productViewModel;
        }

        private void OnProducersChanged(object? sender, EventArgs e)
        {
            // Refresh producers in product view model when they change in producer view model
            _productViewModel.RefreshProducers();
        }

        private void ChangeView(object? parameter)
        {
            if (parameter?.ToString() == "Products")
            {
                CurrentView = _productViewModel;
            }
            else if (parameter?.ToString() == "Producers")
            {
                CurrentView = _producerViewModel;
            }
        }

        private void Add(object? parameter)
        {
            if (CurrentView is ProductViewModel productVM) productVM.AddNewProduct();
            else if (CurrentView is ProducerViewModel producerVM) producerVM.AddNewProducer();
        }

        private void Modify(object? parameter)
        {
            if (CurrentView is ProductViewModel productVM) productVM.EditSelectedProduct();
            else if (CurrentView is ProducerViewModel producerVM) producerVM.EditSelectedProducer(); 
        }

        private void Delete(object? parameter)
        {
            if (CurrentView is ProductViewModel productVM) productVM.DeleteSelectedProduct();
            else if (CurrentView is ProducerViewModel producerVM) producerVM.DeleteSelectedProducer(); 
        }

        private void Search(object? parameter)
        {
            if (CurrentView is ProductViewModel productVM)
            {
                productVM.Search(SearchText);
            }
        }
    }
}