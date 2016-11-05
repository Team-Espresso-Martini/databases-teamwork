using System.Collections.Generic;

namespace ComputersFactory.Data.MySql.ExcelReports.ExcelFileGenerators.Contracts
{
    public interface IExcelFileGenerator
    {
        void GenerateExcelTable<TModel>(IEnumerable<TModel> data, string fileName);
    }
}
