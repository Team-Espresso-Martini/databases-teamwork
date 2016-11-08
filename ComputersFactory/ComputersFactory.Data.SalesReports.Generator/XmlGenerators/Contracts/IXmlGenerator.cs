using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Generator.XmlGenerators.Contracts
{
    public interface IXmlGenerator<TModel>
    {
        void GenererateXmlFiles(IEnumerable<TModel> data);
    }
}
