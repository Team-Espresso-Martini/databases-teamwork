using System.Collections.Generic;

using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts
{
    public interface ISalesReportGenerator : IDataGenerator
    {
        IEnumerable<SalesReport> GenerateReports(int reportsCount);
    }
}
