using ComputersFactory.Models;
using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts
{
    public interface ISaleGenerator : IDataGenerator
    {
        IEnumerable<Sale> GenerateSales(int salesCount);
    }
}
