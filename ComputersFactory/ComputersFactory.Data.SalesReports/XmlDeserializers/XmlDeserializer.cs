using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using ComputersFactory.Data.SalesReports.XmlDeserializers.Contracts;

namespace ComputersFactory.Data.SalesReports.XmlDeserializers
{
    public class XmlDeserializer : IXmlDeserializer
    {
        public IEnumerable<TModel> DeserializeXmlTo<TModel>(string fileName, string rootElement)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var fileExists = File.Exists(fileName);
            if (!fileExists)
            {
                throw new FileNotFoundException(fileName);
            }

            if (string.IsNullOrEmpty(rootElement))
            {
                throw new ArgumentNullException(nameof(rootElement));
            }

            var rootAttribute = new XmlRootAttribute(rootElement);
            var xmlSerializer = new XmlSerializer(typeof(List<TModel>), rootAttribute);

            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var result = (IList<TModel>)xmlSerializer.Deserialize(fileStream);
                return result;
            }
        }
    }
}
