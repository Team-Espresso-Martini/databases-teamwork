using System;
using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.SalesReports.Excel.CompressedExcelDataParsers.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Excel
{
    public class SqlServerExcelSalesReportsImporter : IExcelSalesReportsImporter
    {
        private const string DefaultFileName = @"D:\TeamWorkFiles\XlsReports\reports.zip";
        private const string DefaultTempFileName = @"D:\TeamWorkFiles\XlsReports\temp.xls";

        private readonly ICompressedExcelDataParser<SalesReport> dataParser;
        private readonly AbstractComputersFactoryDbContext context;

        public SqlServerExcelSalesReportsImporter(
            ICompressedExcelDataParser<SalesReport> dataParser,
            AbstractComputersFactoryDbContext context)
        {
            if (dataParser == null)
            {
                throw new ArgumentNullException(nameof(dataParser));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.dataParser = dataParser;
            this.context = context;
        }

        public IList<SalesReport> ImportSalesReportsFromExcel(string fileName, string tempFileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = SqlServerExcelSalesReportsImporter.DefaultFileName;
            }

            if (string.IsNullOrEmpty(tempFileName))
            {
                tempFileName = SqlServerExcelSalesReportsImporter.DefaultTempFileName;
            }

            var reports = this.dataParser.ParseCompressedExcelData(fileName, tempFileName);

            var reportsCount = 0;
            foreach (var report in reports)
            {
                reportsCount++;
                context.SalesReports.Add(report);

                if (reportsCount % 100 == 0)
                {
                    context.SaveChanges();
                }
            }

            context.SaveChanges();

            return reports.ToList();
        }
    }
}
