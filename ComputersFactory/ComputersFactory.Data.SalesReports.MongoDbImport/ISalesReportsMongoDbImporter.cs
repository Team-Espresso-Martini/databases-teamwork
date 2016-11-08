using System.Collections.Generic;

using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.MongoDbImport
{
    public interface ISalesReportsMongoDbImporter
    {
        void ImportSalesReports(IList<SalesReport> reports);
    }
}