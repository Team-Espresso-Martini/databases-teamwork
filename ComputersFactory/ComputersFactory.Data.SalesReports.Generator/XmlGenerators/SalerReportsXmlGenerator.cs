using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

using ComputersFactory.Data.SalesReports.Generator.XmlGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.Generator.XmlGenerators
{
    public class SalesReportsXmlGenerator : IXmlGenerator<SalesReport>
    {
        private const string FileNameFormat = "{0}{1}{2}{3}";
        private const string RootDirectory = "../../../XmlSalesReports";
        private const string Separator = "/";
        private const string Extension = ".xml";

        public void GenererateXmlFiles(IEnumerable<SalesReport> salesReports)
        {
            if (salesReports == null)
            {
                throw new ArgumentNullException(nameof(salesReports));
            }

            var rootDirectoryInfo = new DirectoryInfo(SalesReportsXmlGenerator.RootDirectory);
            if (!rootDirectoryInfo.Exists)
            {
                Directory.CreateDirectory(rootDirectoryInfo.FullName);
            }

            var settings = new XmlWriterSettings() { Indent = true };

            var encoding = Encoding.UTF8;
            using (var writer = XmlWriter.Create("../../../XmlSalesReports/SalesReports.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Reports");

                foreach (var report in salesReports)
                {
                    this.GenerateReportXml(writer, report);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void GenerateReportXml(XmlWriter writer, SalesReport report)
        {
            writer.WriteStartElement("Report");

            writer.WriteElementString("TotalAmount", report.TotalAmount.ToString());
            writer.WriteElementString("Date", report.Date.ToShortDateString());

            writer.WriteStartElement("ComputerShop");
            writer.WriteAttributeString("ComputerShopId", report.ComputerShopId.ToString());
            writer.WriteString(report.ComputerShop.Name);
            writer.WriteEndElement();

            writer.WriteStartElement("Sales");
            foreach (var sale in report.Sales)
            {
                this.GenerateSaleXml(writer, sale);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void GenerateSaleXml(XmlWriter writer, Sale sale)
        {
            writer.WriteStartElement("Sale");

            writer.WriteElementString("Amount", sale.Amount.ToString());

            writer.WriteStartElement("Computer");
            writer.WriteAttributeString("ComputerId", sale.ComputerId.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        private string ResolveFileName(DateTime timeOfReport)
        {
            var reportDate = timeOfReport.ToShortDateString();

            var fileName = string.Format(
                SalesReportsXmlGenerator.FileNameFormat,
                SalesReportsXmlGenerator.RootDirectory,
                SalesReportsXmlGenerator.Separator,
                reportDate,
                SalesReportsXmlGenerator.Extension);

            return fileName;
        }
    }
}
