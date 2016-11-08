using ComputersFactory.Models;
using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Excel
{
    public interface IExcelSalesReportsImporter
    {
        IList<SalesReport> ImportSalesReportsFromExcel(string fileName, string tempFileName);
    }
}