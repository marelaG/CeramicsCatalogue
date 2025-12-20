using System.Windows;
using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Views
{
    public partial class ProductEditorWindow : Window
    {
        public ICeramicItem Item { get; private set; }

        public ProductEditorWindow(ICeramicItem item, IEnumerable<IProducer> producers)
        {
            InitializeComponent();
            Item = item;

            TypeComboBox.ItemsSource = Enum.GetValues(typeof(CeramicType));
            FiringComboBox.ItemsSource = Enum.GetValues(typeof(FiringType));
            ProducerComboBox.ItemsSource = producers;

            NameTextBox.Text = Item.Name;
            ImagePathTextBox.Text = Item.ImagePath;
            TypeComboBox.SelectedItem = Item.CeramicType;
            FiringComboBox.SelectedItem = Item.FiringType;
            
            foreach (IProducer p in ProducerComboBox.ItemsSource)
            {
                if (p.Id == Item.ProducerId)
                {
                    ProducerComboBox.SelectedItem = p;
                    break;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ProducerComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a producer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Item.Name = NameTextBox.Text;
            Item.ImagePath = ImagePathTextBox.Text;
            Item.CeramicType = (CeramicType)TypeComboBox.SelectedItem;
            Item.FiringType = (FiringType)FiringComboBox.SelectedItem;
            
            var selectedProducer = (IProducer)ProducerComboBox.SelectedItem;
            Item.ProducerId = selectedProducer.Id;

            DialogResult = true;
            Close();
        }
    }
}