using System;
using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Excel.CompressedExcelDataParsers.Contracts;
using ComputersFactory.Data.SalesReports.Excel.ExcelDataReaders.Contracts;
using ComputersFactory.Data.SalesReports.Excel.ExcelDataParsers.Contracts;

using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Excel.CompressedExcelDataParsers
{
    public class SalesReportsCompressedExcelDataParser : ICompressedExcelDataParser<SalesReport>
    {
        private readonly IExcelDataReaderProvider readerProvider;
        private readonly IExcelDataParser<SalesReport> dataParser;

        public SalesReportsCompressedExcelDataParser(IExcelDataReaderProvider readerProvider, IExcelDataParser<SalesReport> dataParser)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException(nameof(readerProvider));
            }

            if (dataParser == null)
            {
                throw new ArgumentNullException(nameof(dataParser));
            }

            this.readerProvider = readerProvider;
            this.dataParser = dataParser;
        }

        public IEnumerable<SalesReport> ParseCompressedExcelData(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
