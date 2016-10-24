﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using ComputersFactory.Data.MySql.Migrations;
using ComputersFactory.Data.Services.EntitiyDatabaseServices;
using ComputersFactory.Models.Components;


namespace ComputersFactory.Data.MySql.TestingConsoleClient
{
    public class MySqlTesting
    {
        // Leave for reference, needs a user: root, with password: 1234 to work.
        // Creates a new database named "mycontext".
        private const string ConnectionString = "server=localhost;port=3306;database=mycontext;uid=root;pwd=1234";

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersFactoryMySqlDbContext, MySqlEntityConfiguration>());

            var db = new ComputersFactoryMySqlDbContext();
            db.Database.CreateIfNotExists();

            var service = new EntitiyDatabaseWriterService(db);

            var memory = new Memory
            {
                CapacityInGb = 2,
                Price = 55.00M,
                Manufacturer = "IBM"
            };

            service.SaveDataToDatabase<Memory>(new List<Memory>() { memory });

            Console.WriteLine(db.Memories.Count());
        }
    }
}
