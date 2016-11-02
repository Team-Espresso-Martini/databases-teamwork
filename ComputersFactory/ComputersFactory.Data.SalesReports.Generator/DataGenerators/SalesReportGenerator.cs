using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IList<int> computerShopsIds;

        public SalesReportGenerator(ISaleGenerator saleGenerator, IList<int> computerShopsIds)
        {
            if (saleGenerator == null)
            {
                throw new ArgumentNullException(nameof(saleGenerator));
            }

            if (computerShopsIds == null)
            {
                throw new ArgumentNullException(nameof(computerShopsIds));
            }

            if (computerShopsIds.Count == 0)
            {
                throw new ArgumentException("No ComputerShops Ids.", nameof(computerShopsIds));
            }

            this.saleGenerator = saleGenerator;
            this.computerShopsIds = computerShopsIds;
        }

        public override ICollection<SalesReport> GenerateData(int count)
        {
            var generatedSalesReports = base.GenerateData(count);

            for (int salesReportIndex = 0; salesReportIndex < count; salesReportIndex++)
            {
                var nextSalesReport = new SalesReport();
                nextSalesReport.Date = this.GenerateDate();
                nextSalesReport.Sales = this.GenerateSales();
                nextSalesReport.TotalAmount = this.GenerateSalesAmount(nextSalesReport.Sales);
                nextSalesReport.ComputerShopId = this.GenerateComputerShopId();

                generatedSalesReports.Add(nextSalesReport);
            }

            return generatedSalesReports;
        }

        private ICollection<Sale> GenerateSales()
        {
            var salesCount = base.RandomNumberProvider.Next(SalesReportGenerator.MinimumSalesCount, SalesReportGenerator.MaximumSalesCount);
            var generatedSales = this.saleGenerator.GenerateData(salesCount);

            return generatedSales;
        }

        private decimal GenerateSalesAmount(ICollection<Sale> generatedSales)
        {
            var salesAmount = generatedSales.Select(sale => sale.Amount).Sum();

            return salesAmount;
        }

        private int GenerateComputerShopId()
        {
            var computerShopIdsCount = this.computerShopsIds.Count;
            var computerShopCollectionIndex = base.RandomNumberProvider.Next(0, computerShopIdsCount);
            var computerShopId = this.computerShopsIds[computerShopCollectionIndex];

            return computerShopId;
        }

        private DateTime GenerateDate()
        {
            var year = base.RandomNumberProvider.Next(2014, 2016);
            var month = base.RandomNumberProvider.Next(1, 12);
            var day = base.RandomNumberProvider.Next(1, 28);

            var date = new DateTime(year, month, day);

            return date;
        }
    }
}
