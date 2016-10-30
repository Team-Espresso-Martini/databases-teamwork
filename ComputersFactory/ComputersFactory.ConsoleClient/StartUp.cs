using System;
using System.Data.Entity;
using System.Linq;
using ComputersFactory.Data;
using ComputersFactory.Data.Migrations;
using ComputersFactory.Data.MongoDbWriter;
using MongoDB.Driver;
using ComputersFactory.Models.Components;
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

            // I use this as a flag that it's working :D
            // I'll remove it later
            Console.WriteLine(db.Memories.Count());
        }
    }
}
