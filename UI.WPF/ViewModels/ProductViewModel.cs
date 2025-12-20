using System.Collections.ObjectModel;
using System.Windows;
using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Views;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly CeramicService _service;
        private readonly ProducerService _producerService;

        public ObservableCollection<ICeramicItem> Products { get; set; }

        private ICeramicItem _selectedProduct;
        public ICeramicItem SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        public ProductViewModel()
        {
            _service = new CeramicService(Bootstrapper.CreateCeramicRepository());
            _producerService = new ProducerService(Bootstrapper.CreateProducerRepository());
            
            Products = new ObservableCollection<ICeramicItem>();
            
            LoadData();
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
        
        public void Search(string query)
        {
            var results = _service.Search(query);
            Products.Clear();
            foreach (var item in results) Products.Add(item);
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