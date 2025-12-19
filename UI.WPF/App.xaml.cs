using System.Windows;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new CeramicsDbContext())
            {
                context.Database.Migrate();
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}