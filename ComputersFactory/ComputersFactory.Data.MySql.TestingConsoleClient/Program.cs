using System;
using System.Data.Entity;
using System.Linq;
using ComputersFactory.Data.MySql.Migrations;
using ComputersFactory.Models.Components;
using MySql.Data.MySqlClient;

namespace ComputersFactory.Data.MySql.TestingConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var connection = new MySqlConnection("server=localhost;port=3306;database=mycontext;uid=root;pwd=1234");

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersMySqlDbContext, MySqlEntityConfiguration>());

            var db = new ComputersMySqlDbContext(connection, false);

            try
            {
                db.Database.CreateIfNotExists();

            }
            catch (Exception ex)
            {

                throw;
            }

            //This is for deleting
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
