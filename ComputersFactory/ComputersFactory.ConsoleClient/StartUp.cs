using System.Data.Entity;

using ComputersFactory.Data;
using ComputersFactory.Data.Migrations;
using ComputersFactory.Data.MongoDbWriter;
using ComputersFactory.Data.Repositories.UnitsOfWork;
using ComputersFactory.Data.TransferToSql;

namespace ComputersFactory.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersFactoryDbContext, Configuration>());

            var db = new ComputersFactoryDbContext();
            var worker = new ComputersFactoryUnitOfWork(db);

            MongoDbWriter.GenerateData();
            MongoToSqlMigrator.TransferData();

            //var processorComputers = db.Procesors.Select(p => p.Computers).ToList();
            //foreach (var computersList in processorComputers)
            //{
            //    foreach (var computer in computersList)
            //    {
            //        Console.WriteLine(computer.Model);
            //    }
            //}
        }
    }
}
