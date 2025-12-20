using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Commands;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Views;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly CeramicService _service;
        private readonly ProducerService _producerService;

        public ObservableCollection<ICeramicItem> Products { get; set; }
        public ObservableCollection<IProducer> Producers { get; set; }

        private ICeramicItem _selectedProduct;
        public ICeramicItem SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        private IProducer _selectedProducerFilter;
        public IProducer SelectedProducerFilter
        {
            get => _selectedProducerFilter;
            set 
            { 
                _selectedProducerFilter = value; 
                OnPropertyChanged();
                FilterByProducer();
            }
        }
        
        public ICommand ClearFilterCommand { get; }

        public ProductViewModel()
        {
            _service = new CeramicService(Bootstrapper.CreateCeramicRepository());
            _producerService = new ProducerService(Bootstrapper.CreateProducerRepository());
            
            Products = new ObservableCollection<ICeramicItem>();
            Producers = new ObservableCollection<IProducer>();
            
            ClearFilterCommand = new RelayCommand(ClearFilter);
            
            LoadData();
            LoadProducers();
        }

        public void LoadData()
        {
            var items = _service.GetAll();

            Products.Clear();
            foreach (var item in items)
            {
                Products.Add(item);
            }
            OnPropertyChanged(nameof(Products));
        }

        private void LoadProducers()
        {
            var producers = _producerService.GetAll();
            Producers.Clear();
            foreach (var p in producers)
            {
                Producers.Add(p);
            }
        }
        
        public void Search(string query)
        {
            var results = _service.Search(query);
            Products.Clear();
            foreach (var item in results) Products.Add(item);
        }

        private void FilterByProducer()
        {
            if (SelectedProducerFilter == null)
            {
                LoadData();
            }
            else
            {
                var results = _service.GetByProducer(SelectedProducerFilter.Id);
                Products.Clear();
                foreach (var item in results) Products.Add(item);
            }
        }
        
        private void ClearFilter(object parameter)
        {
            SelectedProducerFilter = null;
        }

        public void AddNewProduct()
        {
            var newItem = new CeramicItemDo(); 
            var producers = _producerService.GetAll();
            
            var editor = new ProductEditorWindow(newItem, producers);
            if (editor.ShowDialog() == true)
            {
                try
                {
                    _service.Add(newItem);
                    LoadData(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error adding product");
                }
            }
        }

        public void EditSelectedProduct()
        {
            if (SelectedProduct == null) return;
            
            var producers = _producerService.GetAll();
            var editor = new ProductEditorWindow(SelectedProduct, producers);
            
            if (editor.ShowDialog() == true)
            {
                try
                {
                    _service.Update(SelectedProduct);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error updating product");
                }
            }
        }

        public void DeleteSelectedProduct()
        {
            if (SelectedProduct == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete {SelectedProduct.Name}?", 
                                         "Confirm Delete", MessageBoxButton.YesNo);
            
            if (result == MessageBoxResult.Yes)
            {
                _service.Delete(SelectedProduct.Id);
                Products.Remove(SelectedProduct);
                SelectedProduct = null;
            }
        }
    }
}