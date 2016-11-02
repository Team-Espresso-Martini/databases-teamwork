using System.Linq;

using ComputersFactory.Models.Views;

namespace ComputersFactory.Data.SalesReports.Generator
{
    public class SalesReportsGeneratorStartup
    {
        public static void Main()
        {
            var context = new ComputersFactoryDbContext();

            var computerShopsIds = context.ComputersShops.Select(cs => cs.Id).ToList();

            var computers = context.Computers.Select(c => new ComputerIdPriceView
            {
                Id = c.Id,
                Price = c.Price
            });
        }
    }
}
