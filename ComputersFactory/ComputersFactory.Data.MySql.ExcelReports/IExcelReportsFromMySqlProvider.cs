using System.Collections.Generic;

using ComputersFactory.Models;

namespace ComputersFactory.Data.MySql.ExcelReports
{
    public interface IExcelReportsFromMySqlProvider
    {
        IList<MySqlReport> CreateExcelReport(string fileName);
    }
}