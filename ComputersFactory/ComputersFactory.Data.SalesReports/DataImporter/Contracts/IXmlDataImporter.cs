using System.Collections.Generic;

using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.DataImporter.Contracts
{
    public interface IXmlDataImporter
    {
        IList<SalesReport> ImportData(string fileName, string rootElement);
    }
}
