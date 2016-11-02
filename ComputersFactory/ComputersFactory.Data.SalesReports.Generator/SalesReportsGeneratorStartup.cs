using System.Linq;

using ComputersFactory.Data.SalesReports.Generator.DataGenerators;
using ComputersFactory.Models.Views;

namespace ComputersFactory.Data.SalesReports.Generator
{
    public class SalesReportsGeneratorStartup
    {
        public static void Main()
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

            var generatedReports = salesRepotsGenerator.GenerateData(15);
        }
    }
}
