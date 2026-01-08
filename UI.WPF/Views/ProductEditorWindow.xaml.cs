using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Views
{
    public partial class ProductEditorWindow : Window
    {
        private readonly ProductEditorViewModel _viewModel;

        public ProductEditorWindow(ICeramicItem item, IEnumerable<IProducer> producers)
        {
            InitializeComponent();
            _viewModel = new ProductEditorViewModel(item, producers);
            DataContext = _viewModel;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.IsValid)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}