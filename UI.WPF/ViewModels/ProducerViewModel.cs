using System.Collections.ObjectModel;
using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Commands;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ProducerViewModel
    {
        private readonly ProducerService _service;

        public ObservableCollection<IProducer> Producers { get; }

        public IProducer? SelectedProducer { get; set; }

        public RelayCommand AddCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public ProducerViewModel()
        {
            var repo = Bootstrapper.CreateProducerRepository();
            _service = new ProducerService(repo);

            Producers = new ObservableCollection<IProducer>(_service.GetAll());

            AddCommand = new RelayCommand(_ => AddProducer());
            DeleteCommand = new RelayCommand(_ => DeleteProducer(), _ => SelectedProducer != null);
        }

        private void AddProducer()
        {
            // TEMPORARY SIMPLE VERSION
            var producer = Producers.FirstOrDefault();
            if (producer == null) return;

            _service.Add(producer);
            Refresh();
        }

        private void DeleteProducer()
        {
            if (SelectedProducer == null) return;

            _service.Delete(SelectedProducer.Id);
            Refresh();
        }

        private void Refresh()
        {
            Producers.Clear();
            foreach (var p in _service.GetAll())
                Producers.Add(p);
        }
    }
}