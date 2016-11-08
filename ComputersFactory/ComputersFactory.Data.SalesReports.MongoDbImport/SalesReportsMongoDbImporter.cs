using System.Collections.Generic;

using ComputersFactory.Models;

using MongoDB.Bson;
using MongoDB.Driver;

namespace ComputersFactory.Data.SalesReports.MongoDbImport
{
    public class SalesReportsMongoDbImporter : ISalesReportsMongoDbImporter
    {
        private const string dbHost = "mongodb://localhost";
        private const string dbName = "ComputersFactory";

        public void ImportSalesReports(IList<SalesReport> reports)
        {
            var client = new MongoClient(dbHost);
            var database = client.GetDatabase(dbName);

            var salesReportsBson = new HashSet<BsonDocument>();
            foreach (var report in reports)
            {
                salesReportsBson.Add(report.ToBsonDocument());
            }

            var salesReportsCollection = database.GetCollection<BsonDocument>("SalesReports");
            salesReportsCollection.InsertMany(salesReportsBson);
        }
    }
}
