using System;
using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Abstract;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators
{
    public class SalesReportGenerator : DataGenerator, ISalesReportGenerator
    {
        private readonly ISaleGenerator saleGenerator;

        public SalesReportGenerator(ISaleGenerator saleGenerator)
        {
            if (saleGenerator == null)
            {
                throw new ArgumentNullException(nameof(saleGenerator));
            }

            this.saleGenerator = saleGenerator;
        }

        public IEnumerable<SalesReport> GenerateReports(int reportsCount)
        {
            throw new NotImplementedException();
        }
    }
}
