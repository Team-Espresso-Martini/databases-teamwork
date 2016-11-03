using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Adapters.Contracts
{
    public interface IAdaptedXmlDeserializer
    {
        IList<TModel> DeserializeXmlTo<TModel>(string fileName, string rootElement);
    }
}
