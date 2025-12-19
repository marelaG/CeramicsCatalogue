using System.Windows.Input;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Commands;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;
        private readonly ProductViewModel _productViewModel;
        private readonly ProducerViewModel _producerViewModel;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangeViewCommand { get; }

        public MainViewModel()
        {
            _productViewModel = new ProductViewModel();
            _producerViewModel = new ProducerViewModel();
            ChangeViewCommand = new RelayCommand(ChangeView);

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
    }
}