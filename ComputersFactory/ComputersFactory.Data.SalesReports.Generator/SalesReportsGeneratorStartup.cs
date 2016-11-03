using System.Linq;

using ComputersFactory.Data.SalesReports.Converters;
using ComputersFactory.Data.SalesReports.DataImporter;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators;
using ComputersFactory.Data.SalesReports.Generator.XmlGenerators;
using ComputersFactory.Data.SalesReports.XmlDeserializers;
using ComputersFactory.Models.Views;

namespace ComputersFactory.Data.SalesReports.Generator
{
    public class SalesReportsGeneratorStartup
    {
        public static void Main()
        {
            SalesReportsGeneratorStartup.GenerateXmlReports();

            var getXmlData = new XmlDeserializer();
            //var data = getXmlData.DeserializeXmlTo<XmlSalesReport>("../../../XmlSalesReports/SalesReports.xml", "Reports");

            var converter = new ModelConverter();
            //var result = converter.Convert<XmlSalesReport, SalesReport>(data);

            var context = new ComputersFactoryDbContext();
            var reportImporter = new XmlSalesReportDataImporter(getXmlData, converter, context);
            reportImporter.ImportData("../../../XmlSalesReports/SalesReports.xml", "Reports");
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
