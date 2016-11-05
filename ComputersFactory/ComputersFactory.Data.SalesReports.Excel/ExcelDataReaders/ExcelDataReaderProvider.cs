using System;
using System.IO;

using ComputersFactory.Data.SalesReports.Excel.ExcelDataReaders.Contracts;

using Excel;

namespace ComputersFactory.Data.SalesReports.Excel.ExcelDataReaders
{
    public class ExcelDataReaderProvider : IExcelDataReaderProvider
    {
        public IExcelDataReader CreateExcelBinaryReader(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var reader = ExcelReaderFactory.CreateBinaryReader(stream);
            return reader;
        }

        public IExcelDataReader CreateExcelOpenXmlReader(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            return reader;
        }
    }
}
