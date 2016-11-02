using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ComputersFactory.Data.SalesReports.XmlModels
{
    [Serializable]
    [XmlType(TypeName = "SalesReport")]
    public class SalesReport
    {
        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; }

        [XmlAttribute]
        public int ComputerShopId { get; set; }

        [XmlArrayItem(ElementName = "Sale")]
        public List<Sale> Sales { get; set; }
    }
}
