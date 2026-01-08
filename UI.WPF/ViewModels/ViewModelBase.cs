using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo implementation
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                return GetValidationError(columnName);
            }
        }

        protected virtual string GetValidationError(string propertyName)
        {
            return null;
        }
        
        // Helper to check if the object is valid
        public bool IsValid
        {
            get
            {
                // This is a simple check. For more complex scenarios, you might need to iterate over all properties.
                // However, since we are using this in ViewModels that wrap entities or properties, 
                // we often check specific properties or rely on the UI validation state.
                // A common pattern is to check if any property returns an error.
                // But since we don't know all properties here easily without reflection, 
                // we will rely on the specific ViewModel to implement a IsValid property or check specific fields before Save.
                return true; 
            }
        }
    }
}
