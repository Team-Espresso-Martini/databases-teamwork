using System.Data.Entity;

namespace ComputersFactory.Data.Xml
{
    public class Startup
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersFactorySqlDbContext, Migrations.Configuration>());
            new ComputersFactorySqlDbContext().Database.Initialize(true);

            //XmlReporter.MakeReport();

            XmlImporter.Import();
        }
        
    }
}
