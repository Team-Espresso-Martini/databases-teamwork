using System;
using System.Collections.Generic;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Abstract;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators
{
    public class SaleGenerator : DataGenerator<Sale>, ISaleGenerator
    {
        public override ICollection<Sale> GenerateData(int count, IList<Computer> availableComputers)
        {
            var generatedSales = base.GenerateData(count, availableComputers);
            var availableComputersCount = availableComputers.Count;

            for (int saleIndex = 0; saleIndex < count; saleIndex++)
            {
                var nextComputerId = base.RandomNumberProvider.Next(0, availableComputersCount);
                var nextComputer = availableComputers[nextComputerId];

                var nextSale = new Sale()
                {
                    Amount = nextComputer.Price,
                    Computer = nextComputer
                };

                generatedSales.Add(nextSale);
            }

            return generatedSales;
        }
    }
}
