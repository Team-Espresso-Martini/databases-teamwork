using System.Linq;

using ComputersFactory.Data.SalesReports.Adapters;
using ComputersFactory.Data.SalesReports.Converters;
using ComputersFactory.Data.SalesReports.DataImporter;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators;
using ComputersFactory.Data.SalesReports.Generator.XmlGenerators;
using ComputersFactory.Data.SalesReports.XmlDeserializers;
using ComputersFactory.Models.Views;
using ComputersFactory.Data.SalesReports.Excel.ExcelDataReaders;
using System.IO;
using ComputersFactory.Data.SalesReports.Excel.ExcelDataParsers;
using ComputersFactory.Data.SalesReports.Excel.CompressedExcelDataParsers;

namespace ComputersFactory.Data.SalesReports.Generator
{
    public class SalesReportsGeneratorStartup
    {
        public static void Main()
        {
            //SalesReportsGeneratorStartup.GenerateXmlReports();

            //var xmlDeserializer = new XmlDeserializer();
            ////var data = getXmlData.DeserializeXmlTo<XmlSalesReport>("../../../XmlSalesReports/SalesReports.xml", "Reports");
            //var adaptedXmlDeserializer = new AdaptedXmlDeserializer(xmlDeserializer);

            //var modelConverter = new ModelConverter();
            ////var result = converter.Convert<XmlSalesReport, SalesReport>(data);
            //var adaptedModelConverter = new AdaptedModelConverter(modelConverter);

            //var context = new ComputersFactoryDbContext();
            //var reportImporter = new XmlSalesReportDataImporter(adaptedXmlDeserializer, adaptedModelConverter, context);
            //reportImporter.ImportData("../../../XmlSalesReports/SalesReports.xml", "Reports");


            var readerProvider = new ExcelDataReaderProvider();

            var parser = new SalesReportsExcelDataParser();

            var extractor = new SalesReportsCompressedExcelDataParser(readerProvider, parser);
            extractor.ParseCompressedExcelData(@"D:\TeamWorkFiles\XlsReports\reports.zip", @"D:\TeamWorkFiles\XlsReports\temp.xls");
        }

        private static void GenerateXmlReports()
        {
            var context = new ComputersFactoryDbContext();

            var computerShopsIds = context.ComputersShops.ToList();

            var computers = context.Computers.Select(c => new ComputerIdPriceView
            {
                Id = c.Id,
                Price = c.Price
            })
            .ToList();

            var saleGenerator = new SaleGenerator(computers);
            var salesRepotsGenerator = new SalesReportGenerator(saleGenerator, computerShopsIds);

            var generatedReports = salesRepotsGenerator.GenerateData(100);

            var xmlWriter = new SalesReportsXmlGenerator();
            xmlWriter.GenererateXmlFiles(generatedReports);
        }
    }
}
