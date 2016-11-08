using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;
using System.Linq;

using ComputersFactory.Data.SalesReports.Excel.OleDb.Factories;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Excel.OleDb.DataParsers
{
    public class OleDbExcelSalesReportsParser : IOleDbExcelSalesReportsParser
    {
        private const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\TeamWorkFiles\XlsReports\temp.xls;Mode=ReadWrite;Extended Properties=""Excel 8.0;HDR=YES;MaxScanRows=0;IMEX=0"";";
        private const string CommandString = @"SELECT * FROM [Table1]";

        private const string DefaultFileName = @"D:\TeamWorkFiles\XlsReports\reports.zip";
        private const string DefaultTempFileName = @"D:\TeamWorkFiles\XlsReports\temp.xls";

        private readonly IOleDbCommandFactory commandFactory;
        private readonly IOleDbConnectionFactory connectionFactory;

        public OleDbExcelSalesReportsParser(IOleDbCommandFactory commandFactory, IOleDbConnectionFactory connectionFactory)
        {
            if (commandFactory == null)
            {
                throw new ArgumentNullException(nameof(commandFactory));
            }

            if (connectionFactory == null)
            {
                throw new ArgumentNullException(nameof(connectionFactory));
            }

            this.commandFactory = commandFactory;
            this.connectionFactory = connectionFactory;
        }

        public IList<SalesReport> ParseExcelReports(string zipFileName = null)
        {
            if (string.IsNullOrEmpty(zipFileName))
            {
                zipFileName = OleDbExcelSalesReportsParser.DefaultFileName;
            }

            var tempFileName = OleDbExcelSalesReportsParser.DefaultTempFileName;

            var salesReports = new List<SalesReport>();
            using (var archive = ZipFile.Open(zipFileName, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    File.Delete(tempFileName);
                    entry.ExtractToFile(tempFileName);

                    var command = this.commandFactory.CreateOleDbCommand(OleDbExcelSalesReportsParser.CommandString);
                    var connection = this.connectionFactory.CreateOleDbConnection(OleDbExcelSalesReportsParser.ConnectionString);
                    command.Connection = connection;

                    connection.Open();
                    using (connection)
                    {
                        var reader = command.ExecuteReader();
                        var salesReport = this.ReadReport(reader);

                        var entryNameWords = entry.Name.Split(new[] { '-', '.' }, StringSplitOptions.RemoveEmptyEntries);
                        var computerShopId = this.ExtractComputerShopIdFromFileName(entryNameWords);
                        salesReport.ComputerShopId = computerShopId;

                        var date = this.ExtractDateFromFileName(entryNameWords);
                        salesReport.Date = date;

                        salesReport.TotalAmount = salesReport.Sales.Select(s => s.Amount).Sum();

                        salesReports.Add(salesReport);
                    }
                }
            }

            return salesReports;
        }

        private SalesReport ReadReport(OleDbDataReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            var sales = new List<Sale>();
            while (reader.Read())
            {
                var computerId = (string)reader["ComputerId"];
                var amount = (string)reader["Amount"];

                var nextSale = new Sale();
                nextSale.ComputerId = int.Parse(computerId);
                nextSale.Amount = decimal.Parse(amount);

                sales.Add(nextSale);
            }

            var salesReport = new SalesReport();
            salesReport.Sales = sales;

            return salesReport;
        }

        private DateTime ExtractDateFromFileName(IList<string> words)
        {
            var wordsLength = words.Count;
            var year = int.Parse(words[wordsLength - 2]);
            var month = int.Parse(words[wordsLength - 3]);
            var day = int.Parse(words[wordsLength - 4]);

            var date = new DateTime(year, month, day);

            return date;
        }

        private int ExtractComputerShopIdFromFileName(IList<string> words)
        {
            var wordsLength = words.Count;
            var computerShopId = int.Parse(words[wordsLength - 5]);

            return computerShopId;
        }
    }
}
