using System.Collections.ObjectModel;
using System.Windows;
using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Views;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ProducerViewModel : ViewModelBase 
    {
        private readonly ProducerService _service;
        
        public ObservableCollection<IProducer> Producers { get; set; }
        
        private IProducer _selectedProducer;
        public IProducer SelectedProducer
        {
            get => _selectedProducer;
            set { _selectedProducer = value; OnPropertyChanged(); }
        }

        public ProducerViewModel()
        {
            var repo = Bootstrapper.CreateProducerRepository();
            _service = new ProducerService(repo);
            Producers = new ObservableCollection<IProducer>();
            LoadData();
        }

        private void LoadData()
        {
            Producers.Clear();
            foreach (var p in _service.GetAll()) Producers.Add(p);
        }

        public void AddNewProducer()
        {
            // We need to create a new instance of IProducer. 
            // Since we don't have reference to DAO (where ProducerDo is), we need a factory or use the service/bootstrapper.
            // For now, let's assume Bootstrapper can provide a new instance or we use a factory interface.
            
            var newProducer = Bootstrapper.CreateProducer();
            var editor = new ProducerEditorWindow(newProducer);
            if (editor.ShowDialog() == true)
            {
                try
                {
                    _service.Add(newProducer);
                    LoadData();
                }
                catch (System.Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        public void EditSelectedProducer()
        {
            if (SelectedProducer == null) return;
            var editor = new ProducerEditorWindow(SelectedProducer);
            if (editor.ShowDialog() == true)
            {
                try
                {
                    _service.Update(SelectedProducer);
                    LoadData();
                }
                catch (System.Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        public void DeleteSelectedProducer()
        {
            if (SelectedProducer == null) return;
            if (MessageBox.Show($"Delete {SelectedProducer.Name}?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _service.Delete(SelectedProducer.Id);
                LoadData();
            }
        }
    }
}