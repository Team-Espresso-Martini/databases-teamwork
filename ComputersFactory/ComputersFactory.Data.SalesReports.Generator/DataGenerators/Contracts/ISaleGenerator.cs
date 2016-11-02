﻿using System.Collections.Generic;

using ComputersFactory.Data.Models;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts
{
    public interface ISaleGenerator : IDataGenerator
    {
        IEnumerable<Sale> GenerateSales(int salesCount, IList<Computer> availableComputers);
    }
}
