using System.Collections.Generic;

using Excel;

namespace ComputersFactory.Data.SalesReports.Excel.ExcelDataParsers.Contracts
{
    public interface IExcelDataParser<TModel> where TModel : new()
    {
        TModel ParseExcelDataReader(IExcelDataReader reader);
    }
}
