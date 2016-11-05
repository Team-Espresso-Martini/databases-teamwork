using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.Json.Contracts;
using ComputersFactory.Data.MySql;
using ComputersFactory.Models;

namespace ComputersFactory.Data.Json.Facade
{
    public class WriteJsonReportsFacade : IWriteJsonReportsFacade
    {
        private const string RootDirectory = @"D:\TeamWorkFiles\GeneratedJson";

        private readonly IJsonService jsonService;
        private readonly IMySqlDatabaseContext mySqlContext;
        private readonly AbstractComputersFactoryDbContext sqlServercontext;

        public WriteJsonReportsFacade(
            IJsonService jsonService,
            IMySqlDatabaseContext mySqlContext,
            AbstractComputersFactoryDbContext sqlServercontext)
        {
            this.jsonService = jsonService;
            this.mySqlContext = mySqlContext;
            this.sqlServercontext = sqlServercontext;
        }

        public IEnumerable<MySqlReport> GenerateXmlReports()
        {
            var computers = this.sqlServercontext.Computers.ToList();

            var reports = new List<MySqlReport>();
            foreach (var pc in computers)
            {
                var totalQuantity = this.sqlServercontext.Sales
                    .Where(s => s.ComputerId == pc.Id).Count();

                var newReport = new MySqlReport()
                {
                    Model = pc.Model,
                    TotalSales = pc.Price * totalQuantity,
                    TotalQuantity = totalQuantity
                };

                reports.Add(newReport);
                this.mySqlContext.Reports.Add(newReport);
            }

            this.jsonService.SaveModelDataToFileSystemAsJson<MySqlReport>(reports, RootDirectory);
            this.mySqlContext.SaveChanges();

            return reports;
        }
    }
}
