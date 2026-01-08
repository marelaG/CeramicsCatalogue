using System.Windows;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.InitializeDatabase();

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}