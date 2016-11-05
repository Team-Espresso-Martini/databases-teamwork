using System.IO;

using Excel;

namespace ComputersFactory.Data.SalesReports.Excel.ExcelDataReaders.Contracts
{
    public interface IExcelDataReaderProvider
    {
        IExcelDataReader CreateExcelBinaryReader(Stream stream);

        IExcelDataReader CreateExcelOpenXmlReader(Stream stream);
    }
}
