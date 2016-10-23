using System;
using System.Data.Entity;
using System.Linq;

using ComputersFactory.Data.MySql.Migrations;
using ComputersFactory.Models.Components;
using ComputersFactory.Data.Services;
using System.Collections.Generic;

namespace ComputersFactory.Data.MySql.TestingConsoleClient
{
    public class MySqlTesting
    {
        // Leave for reference
        private const string ConnectionString = "server=localhost;port=3306;database=mycontext;uid=root;pwd=1234";

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersFactoryMySqlDbContext, MySqlEntityConfiguration>());

            var db = new ComputersFactoryMySqlDbContext();
            db.Database.CreateIfNotExists();

            var service = new EntitiyDatabaseService(db);

            var memory = new Memory
            {
                CapacityInGb = 2,
                Price = 50.00M,
                Manufacturer = "IBM"
            };

            service.SaveDataToDatabase<Memory>(new List<Memory>() { memory });

            //var props = db.GetType().GetProperties();
            //foreach (var item in props)
            //{
            //    if (item.PropertyType.IsGenericType)
            //    {
            //        Console.WriteLine(item.PropertyType.GetGenericArguments()[0].Name);
            //    }
            //}

            //var type = db.Memories.GetType().GetMethod("Add");

            //db.Memories.Add(memory);
            //db.SaveChanges();

            Console.WriteLine(db.Memories.Count());
        }
    }
}
