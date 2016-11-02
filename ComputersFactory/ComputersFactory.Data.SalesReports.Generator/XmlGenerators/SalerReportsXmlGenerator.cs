using System;
using System.Collections.Generic;
using System.IO;

using ComputersFactory.Data.SalesReports.Generator.XmlGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.XmlGenerators
{
    public class SalerReportsXmlGenerator : IXmlGenerator<SalesReport>
    {
        private const string RootDirectory = "../../../XmlSalesReports";

        public void GenererateXmlFiles(IEnumerable<SalesReport> salesReports)
        {
            if (salesReports == null)
            {
                throw new ArgumentNullException(nameof(salesReports));
            }

            var rootDirectoryInfo = new DirectoryInfo(SalerReportsXmlGenerator.RootDirectory);
            if (!rootDirectoryInfo.Exists)
            {
                Directory.CreateDirectory(rootDirectoryInfo.FullName);
            }

            foreach (var report in salesReports)
            {
                var reportFileName = this.ResolveFileName(report.Date);
            }
        }

        private string ResolveFileName(DateTime timeOfReport)
        {
            throw new NotImplementedException();
        }
    }
}
