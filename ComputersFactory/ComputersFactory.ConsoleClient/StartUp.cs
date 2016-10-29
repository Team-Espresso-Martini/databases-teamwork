using System;
using System.Data.Entity;
using System.Linq;
using ComputersFactory.Data;
using ComputersFactory.Data.Migrations;
using ComputersFactory.Data.MongoDbWriter;
using MongoDB.Driver;
using ComputersFactory.Models.Components;
using ComputersFactory.Data.Repositories.UnitsOfWork;

namespace ComputersFactory.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersFactoryDbContext, Configuration>());

            var db = new ComputersFactoryDbContext();
            var worker = new ComputersFactoryUnitOfWork(db);

            //This is for deleting
            //var memory = new Memory
            //{
            //    CapacityInGb = 2,
            //    Price = 50.00M,
            //    Manufacturer = "IBM"
            //};

            //db.Memories.Add(memory);
            //db.SaveChanges();

            Console.WriteLine(db.Memories.Count());

            MongoDbWriter.GenerateData();
        }
    }
}
