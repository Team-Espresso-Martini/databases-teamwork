using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ComputersFactory.Data.SalesReports.XmlModels
{
    [Serializable]
    [XmlType(TypeName = "SalesReport")]
    public class XmlSalesReport
    {
        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; }

        [XmlAttribute]
        public int ComputerShopId { get; set; }

        public string ComputerShop { get; set; }

        [XmlArrayItem(ElementName = "Sale")]
        public List<XmlSale> Sales { get; set; }
    }
}
