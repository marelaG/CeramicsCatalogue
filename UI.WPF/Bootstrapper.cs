using System.Configuration;
using System.IO;
using System.Reflection;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF
{
    public static class Bootstrapper
    {
        private static Assembly _daoAssembly;

        private static Assembly GetDaoAssembly()
        {
            if (_daoAssembly == null)
            {
                var assemblyName = ConfigurationManager.AppSettings["DaoAssembly"];
                try 
                {
                    _daoAssembly = Assembly.Load(assemblyName);
                }
                catch
                {
                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName + ".dll");
                    _daoAssembly = Assembly.LoadFrom(path);
                }
            }
            return _daoAssembly;
        }

        private static T Create<T>()
        {
            var assembly = GetDaoAssembly();
            var type = assembly.GetTypes()
                .First(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            return (T)Activator.CreateInstance(type)!;
        }

        public static ICeramicRepository CreateCeramicRepository() =>
            Create<ICeramicRepository>();

        public static IProducerRepository CreateProducerRepository() =>
            Create<IProducerRepository>();
            
        public static IProducer CreateProducer() => Create<IProducer>();
        
        public static ICeramicItem CreateCeramicItem() => Create<ICeramicItem>();

        public static void InitializeDatabase()
        {
            try
            {
                var initializer = Create<IDatabaseInitializer>();
                initializer.Initialize();
            }
            catch
            {
                // Ignore if no initializer found or initialization fails (might not be needed)
            }
        }
    }
}