using GancewskaKerebinska.CeramicsCatalogue.DAO.Context;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces;

namespace GancewskaKerebinska.CeramicsCatalogue.DAO
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        public void Initialize()
        {
            using (var context = new CeramicsDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}