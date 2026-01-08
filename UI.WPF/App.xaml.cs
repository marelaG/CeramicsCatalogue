using System.Windows;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.InitializeDatabase();

            // MainWindow is set via StartupUri in App.xaml or created here if StartupUri is removed.
            // Since StartupUri is not in App.xaml, we create it here.
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}