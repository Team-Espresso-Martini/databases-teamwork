using System;
using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Excel.ExcelDataParsers.Contracts;
using ComputersFactory.Models;

using Excel;

namespace ComputersFactory.Data.SalesReports.Excel.ExcelDataParsers
{
    public class SalesReportsExcelDataParser : IExcelDataParser<SalesReport>
    {
        public SalesReport ParseExcelDataReader(IExcelDataReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            var sales = new List<Sale>();
            while (reader.Read())
            {
                var computerId = reader.GetString(0);
                var amount = reader.GetString(1);

                var nextSale = new Sale();
                nextSale.ComputerId = int.Parse(computerId);
                nextSale.Amount = decimal.Parse(amount);

                sales.Add(nextSale);
            }

            var salesReport = new SalesReport();
            salesReport.Sales = sales;

            return salesReport;
        }
    }
}
