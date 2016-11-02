using System.Linq;

using ComputersFactory.Models.Views;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators;

namespace ComputersFactory.Data.SalesReports.Generator
{
    public class SalesReportsGeneratorStartup
    {
        public static void Main()
        {
            var context = new ComputersFactoryDbContext();

            var computerShopsIds = context.ComputersShops
                .Select(cs => cs.Id)
                .ToList();

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
