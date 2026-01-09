using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo implementation
        public string? Error => null;

        public string? this[string columnName]
        {
            get
            {
                return GetValidationError(columnName);
            }
        }

        protected virtual string? GetValidationError(string propertyName)
        {
            return null;
        }
        
        public virtual bool IsValid
        {
            get
            {
                return true; 
            }
        }
    }
}