﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

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

        public IEnumerable<SalesReport> ParseCompressedExcelData(string fileName, string tempFileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrEmpty(tempFileName))
            {
                throw new ArgumentNullException(nameof(tempFileName));
            }

            var salesReports = new List<SalesReport>();
            using (var archive = ZipFile.Open(fileName, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    entry.ExtractToFile(tempFileName);
                    using (var stream = new FileStream(tempFileName, FileMode.Open, FileAccess.Read))
                    {
                        var excelReader = this.readerProvider.CreateExcelBinaryReader(stream);
                        var salesReport = this.dataParser.ParseExcelDataReader(excelReader);

                        var entryNameWords = entry.Name.Split('-');
                        var computerShopId = this.ExtractComputerShopIdFromFileName(entryNameWords);
                        salesReport.ComputerShopId = computerShopId;

                        var date = this.ExtractDateFromFileName(entryNameWords);
                        salesReport.Date = date;

                        salesReports.Add(salesReport);
                    }
                }

                File.Delete(tempFileName);
            }

            return salesReports;
        }

        private DateTime ExtractDateFromFileName(IList<string> words)
        {
            var wordsLength = words.Count;
            var year = int.Parse(words[wordsLength - 1]);
            var month = int.Parse(words[wordsLength - 2]);
            var day = int.Parse(words[wordsLength - 3]);

            var date = new DateTime(year, month, day);

            return date;
        }

        private int ExtractComputerShopIdFromFileName(IList<string> words)
        {
            var wordsLength = words.Count;
            var computerShopId = int.Parse(words[wordsLength - 4]);

            return computerShopId;
        }
    }
}
