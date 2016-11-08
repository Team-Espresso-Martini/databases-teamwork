using System;
using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Abstract;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts;
using ComputersFactory.Models;
using ComputersFactory.Models.Views;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators
{
    public class SaleGenerator : DataGenerator<Sale>, ISaleGenerator
    {
        private readonly IList<ComputerIdPriceView> availableComputers;

        public SaleGenerator(IList<ComputerIdPriceView> availableComputers)
        {
            if (availableComputers == null)
            {
                throw new ArgumentNullException(nameof(availableComputers));
            }

            if (availableComputers.Count == 0)
            {
                throw new ArgumentException("No AvialableComputers.", nameof(availableComputers));
            }

            this.availableComputers = availableComputers;
        }

        public override ICollection<Sale> GenerateData(int count)
        {
            var generatedSales = base.GenerateData(count);
            var availableComputersCount = availableComputers.Count;

            for (int saleIndex = 0; saleIndex < count; saleIndex++)
            {
                var nextComputerId = base.RandomNumberProvider.Next(0, availableComputersCount);
                var nextComputer = availableComputers[nextComputerId];

                var nextSale = new Sale()
                {
                    Amount = nextComputer.Price,
                    ComputerId = nextComputer.Id
                };

                generatedSales.Add(nextSale);
            }

            return generatedSales;
        }
    }
}
