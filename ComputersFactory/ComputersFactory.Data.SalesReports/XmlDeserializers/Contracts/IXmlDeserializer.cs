using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.XmlDeserializers.Contracts
{
    public interface IXmlDeserializer
    {
        IList<TModel> DeserializeXmlTo<TModel>(string fileName, string rootElement);
    }
}
