using System;
using System.Collections.Generic;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Abstract;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators
{
    public class SaleGenerator : DataGenerator, ISaleGenerator
    {
        public IEnumerable<Sale> GenerateSales(int salesCount, IList<Computer> availableComputers)
        {
            if (availableComputers == null)
            {
                throw new ArgumentNullException(nameof(availableComputers));
            }

            if (availableComputers.Count == 0)
            {
                throw new ArgumentException("Available computers collection is empty.", nameof(availableComputers));
            }

            if (salesCount <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be larger than zero.");
            }

            var availableComputersCount = availableComputers.Count;

            var generatedSales = new List<Sale>();
            for (int saleIndex = 0; saleIndex < salesCount; saleIndex++)
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
