using System;
using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Abstract;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators
{
    public class SalesReportGenerator : DataGenerator<SalesReport>, ISalesReportGenerator
    {
        private const int MinimumSalesCount = 3;
        private const int MaximumSalesCount = 15;

        private readonly ISaleGenerator saleGenerator;

        public SalesReportGenerator(ISaleGenerator saleGenerator)
        {
            if (saleGenerator == null)
            {
                throw new ArgumentNullException(nameof(saleGenerator));
            }

            this.saleGenerator = saleGenerator;
        }

        public ICollection<SalesReport> GenerateData(int count, IList<Computer> availableComputers)
        {
            var generatedSalesReports = base.GenerateData(count, availableComputers);

            var salesCount = base.RandomNumberProvider.Next(SalesReportGenerator.MinimumSalesCount, SalesReportGenerator.MaximumSalesCount);

            var generatedSales = this.saleGenerator.GenerateData(salesCount, availableComputers);
            var salesAmountInMoney = generatedSales.Select(sale => sale.Amount).Sum();
        }
    }
}
