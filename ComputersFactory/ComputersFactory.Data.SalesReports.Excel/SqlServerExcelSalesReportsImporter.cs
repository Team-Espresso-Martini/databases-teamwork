using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.SalesReports.Excel.CompressedExcelDataParsers.Contracts;
using ComputersFactory.Data.SalesReports.Excel.ExcelDataParsers.Contracts;
using ComputersFactory.Data.SalesReports.Excel.ExcelDataReaders.Contracts;
using ComputersFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersFactory.Data.SalesReports.Excel
{
    public class SqlServerExcelSalesReportsImporter : IExcelSalesReportsImporter
    {
        public SqlServerExcelSalesReportsImporter(
             ICompressedExcelDataParser<SalesReport> dataParser,
            AbstractComputersFactoryDbContext context)
        {

        }

        public void ImportSalesReportsFromExcel(string fileName, string tempFileName)
        {

        }
    }
}
