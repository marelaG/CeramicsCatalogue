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
                // Ensure the database is created and schema is up to date
                // For development purposes, we can delete and recreate the database to apply changes
                // In production, use Migrations
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}