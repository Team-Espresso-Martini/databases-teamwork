using System;
using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Generator.XmlGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.XmlGenerators
{
    public class SalerReportsXmlGenerator : IXmlGenerator<SalesReport>
    {
        public void GenererateXmlFiles(IEnumerable<SalesReport> data)
        {
            throw new NotImplementedException();
        }
    }
}
