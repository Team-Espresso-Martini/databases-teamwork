using ComputersFactory.Models.Components;
using MongoDB.Driver;
using System;

namespace ComputersFactory.MongoDbWriter
{
    public static class MongoDbWriter
    {
        public static IMongoDatabase Write()
        {
            var connectionString = "mongodb://localhost";
            var dbName = "ComputersFactory";
            var computersFactoryDb = GetDatabase(connectionString, dbName);

            return computersFactoryDb;        
        }

        private static IMongoDatabase GetDatabase(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);

            return client.GetDatabase(dbName);
        }
    }
}
