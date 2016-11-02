using System;
using System.Xml.Serialization;

namespace ComputersFactory.Data.SalesReports.XmlModels
{
    [Serializable]
    [XmlType(TypeName = "Sale")]
    public class Sale
    {
        public decimal Amount { get; set; }

        [XmlAttribute]
        public int ComputerId { get; set; }
    }
}
