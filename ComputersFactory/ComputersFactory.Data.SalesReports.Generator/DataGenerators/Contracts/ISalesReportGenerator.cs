using System.Collections.Generic;

using ComputersFactory.Models;
using ComputersFactory.Data.Models;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts
{
    public interface ISalesReportGenerator : IDataGenerator
    {
        ICollection<SalesReport> GenerateData(int count, IList<Computer> availableComputers);
    }
}
