using System.Collections.Generic;

using ComputersFactory.Models;

namespace ComputersFactory.Data.MySql.ExcelReports.ExcelFileGenerators.Contracts
{
    public interface IExcelFileGenerator
    {
        void GenerateExcelTable(IEnumerable<MySqlReport> data, string fileName);
    }
}
