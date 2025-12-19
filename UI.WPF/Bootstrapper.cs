using System.Configuration;
using System.Reflection;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

namespace GancewskaKerebinska.CeramicsCatalogue.UI.WPF
{
    public static class Bootstrapper
    {
        private static T Create<T>()
        {
            var assemblyName = ConfigurationManager.AppSettings["DaoAssembly"];
            var assembly = Assembly.Load(assemblyName);

            var type = assembly.GetTypes()
                .First(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface);

            return (T)Activator.CreateInstance(type)!;
        }

        public static ICeramicRepository CreateCeramicRepository() =>
            Create<ICeramicRepository>();

        public static IProducerRepository CreateProducerRepository() =>
            Create<IProducerRepository>();
    }
}