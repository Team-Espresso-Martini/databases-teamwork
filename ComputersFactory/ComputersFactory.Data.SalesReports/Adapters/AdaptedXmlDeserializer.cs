using System;
using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Adapters.Contracts;
using ComputersFactory.Data.SalesReports.XmlDeserializers.Contracts;

namespace ComputersFactory.Data.SalesReports.Adapters
{
    public class AdaptedXmlDeserializer : IAdaptedXmlDeserializer, IXmlDeserializer
    {
        private readonly IXmlDeserializer xmlDeserializer;

        public AdaptedXmlDeserializer(IXmlDeserializer xmlDeserializer)
        {
            if (xmlDeserializer == null)
            {
                throw new ArgumentNullException(nameof(xmlDeserializer));
            }

            this.xmlDeserializer = xmlDeserializer;
        }

        public IEnumerable<TModel> DeserializeXmlTo<TModel>(string fileName, string rootElement)
        {
            return this.xmlDeserializer.DeserializeXmlTo<TModel>(fileName, rootElement);
        }

        public IList<TModel> DeserializeXmlToIListOf<TModel>(string fileName, string rootElement)
        {
            var deserializedData = this.xmlDeserializer.DeserializeXmlTo<TModel>(fileName, rootElement);

            var adaptedList = new List<TModel>(deserializedData);
            return adaptedList;
        }
    }
}
