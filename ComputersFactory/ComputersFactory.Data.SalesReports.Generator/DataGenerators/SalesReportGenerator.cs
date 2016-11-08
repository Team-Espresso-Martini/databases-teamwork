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
        private readonly IList<ComputerShop> computerShops;

        public SalesReportGenerator(ISaleGenerator saleGenerator, IList<ComputerShop> computerShops)
        {
            if (saleGenerator == null)
            {
                throw new ArgumentNullException(nameof(saleGenerator));
            }

            if (computerShops == null)
            {
                throw new ArgumentNullException(nameof(computerShops));
            }

            if (computerShops.Count == 0)
            {
                throw new ArgumentException("No ComputerShops Ids.", nameof(computerShops));
            }

            this.saleGenerator = saleGenerator;
            this.computerShops = computerShops;
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
                nextSalesReport.ComputerShop = this.GenerateComputerShopId();
                nextSalesReport.ComputerShopId = nextSalesReport.ComputerShop.Id;

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

        private ComputerShop GenerateComputerShopId()
        {
            var computerShopsCount = this.computerShops.Count;
            var computerShopCollectionIndex = base.RandomNumberProvider.Next(0, computerShopsCount);
            var computerShop = this.computerShops[computerShopCollectionIndex];

            return computerShop;
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
