using System;
using System.Data.Entity;
using System.Linq;

using ComputersFactory.Data.MySql.Migrations;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data.MySql.TestingConsoleClient
{
    public class Program
    {
        // Leave for reference
        private const string ConnectionString = "server=localhost;port=3306;database=mycontext;uid=root;pwd=1234";

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersMySqlDbContext, MySqlEntityConfiguration>());

            var db = new ComputersMySqlDbContext();
            db.Database.CreateIfNotExists();

            var memory = new Memory
            {
                CapacityInGb = 2,
                Price = 50.00M,
                Manufacturer = "IBM"
            };

            db.Memories.Add(memory);
            db.SaveChanges();

            Console.WriteLine(db.Memories.Count());
        }
    }
}
