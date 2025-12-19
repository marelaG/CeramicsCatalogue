using System.Windows.Input;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Commands;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;
        private readonly ProductViewModel _productViewModel;
        private readonly ProducerViewModel _producerViewModel;
        private string _searchText;

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
            ChangeViewCommand = new RelayCommand(ChangeView);
            AddCommand = new RelayCommand(Add);
            ModifyCommand = new RelayCommand(Modify);
            DeleteCommand = new RelayCommand(Delete);
            SearchCommand = new RelayCommand(Search);

            // Set the initial view
            CurrentView = _productViewModel;
        }

        private void ChangeView(object parameter)
        {
            if (parameter.ToString() == "Products")
            {
                CurrentView = _productViewModel;
            }
            else if (parameter.ToString() == "Producers")
            {
                CurrentView = _producerViewModel;
            }
        }

        private void Add(object parameter)
        {
            // TODO: Implement Add functionality
        }

        private void Modify(object parameter)
        {
            // TODO: Implement Modify functionality
        }



        private void Delete(object parameter)
        {
            // TODO: Implement Delete functionality
        }

        private void Search(object parameter)
        {
            // TODO: Implement Search functionality
        }
    }
}