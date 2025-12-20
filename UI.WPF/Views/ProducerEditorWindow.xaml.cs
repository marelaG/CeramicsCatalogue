using System.Windows;
using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.Views
{
    public partial class ProducerEditorWindow : Window
    {
        public IProducer Producer { get; }

        public ProducerEditorWindow(IProducer producer)
        {
            InitializeComponent();
            Producer = producer;

            CountryComboBox.ItemsSource = Enum.GetValues(typeof(Country));

            NameTextBox.Text = Producer.Name;
            CountryComboBox.SelectedItem = Producer.Country;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Name is required.", "Error");
                return;
            }

            Producer.Name = NameTextBox.Text;
            Producer.Country = (Country)CountryComboBox.SelectedItem;

            DialogResult = true;
            Close();
        }
    }
}