using ComputersFactory.Models;
using System.Collections.Generic;

using Telerik.OpenAccess.Metadata.Fluent;

namespace ComputersFactory.Data.MySql.OpenAccess
{
    public partial class MySqlReportsMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations =
                new List<MappingConfiguration>();

            var customerMapping = new MappingConfiguration<MySqlReport>();
            customerMapping.MapType(report => new
            {
                Id = report.Id,
                Model = report.Model,
                TotalSales = report.TotalSales,
                TotalQuantity = report.TotalQuantity
            }).ToTable("Customer");
            customerMapping.HasProperty(c => c.Id).IsIdentity();

            configurations.Add(customerMapping);

            return configurations;
        }
    }
}
