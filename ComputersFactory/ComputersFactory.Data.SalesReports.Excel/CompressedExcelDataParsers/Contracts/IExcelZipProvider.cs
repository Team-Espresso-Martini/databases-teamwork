using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Excel.CompressedExcelDataParsers.Contracts
{
    public interface ICompressedExcelDataParser<TModel>
    {
        IEnumerable<TModel> ParseCompressedExcelData(string fileName);
    }
}
