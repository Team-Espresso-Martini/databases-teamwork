using System.Collections.Generic;

using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Excel.OleDb.DataParsers
{
    public interface IOleDbExcelSalesReportsParser
    {
        IList<SalesReport> ParseExcelReports(string zipFileName = null);
    }
}