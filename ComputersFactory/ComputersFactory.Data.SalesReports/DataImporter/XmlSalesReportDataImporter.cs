using System;
using System.Collections.Generic;

using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.SalesReports.Adapters.Contracts;
using ComputersFactory.Data.SalesReports.DataImporter.Contracts;
using ComputersFactory.Data.SalesReports.XmlModels;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.DataImporter
{
    /// <summary>
    /// Expects 30+ ComputerShops, Run Task 1 Twice
    /// </summary>
    public class XmlSalesReportDataImporter : IXmlDataImporter
    {
        private readonly IAdaptedXmlDeserializer xmlDeserializer;
        private readonly IAdaptedModelConverter modelConverter;
        private readonly AbstractComputersFactoryDbContext context;

        public XmlSalesReportDataImporter(IAdaptedXmlDeserializer xmlDeserializer, IAdaptedModelConverter modelConverter, AbstractComputersFactoryDbContext context)
        {
            if (xmlDeserializer == null)
            {
                throw new ArgumentNullException(nameof(xmlDeserializer));
            }

            if (modelConverter == null)
            {
                throw new ArgumentNullException(nameof(modelConverter));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.xmlDeserializer = xmlDeserializer;
            this.modelConverter = modelConverter;
            this.context = context;
        }

        public IList<SalesReport> ImportData(string fileName, string rootElement)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrEmpty(rootElement))
            {
                throw new ArgumentNullException(nameof(rootElement));
            }

            var salesReportsFromXml = this.xmlDeserializer.DeserializeXmlToIListOf<XmlSalesReport>(fileName, rootElement);
            var salesReportsWithoutNestedCollection = this.modelConverter.ConvertToIList<XmlSalesReport, SalesReport>(salesReportsFromXml);

            var createdReports = new List<SalesReport>();

            var reportsCount = salesReportsFromXml.Count;
            for (int reportIndex = 0; reportIndex < reportsCount; reportIndex++)
            {
                var importedReport = salesReportsFromXml[reportIndex];
                var exportedReport = salesReportsWithoutNestedCollection[reportIndex];

                var sales = this.modelConverter.ConvertToIList<XmlSale, Sale>(importedReport.Sales);
                exportedReport.Sales = sales;

                this.context.SalesReports.Add(exportedReport);
                createdReports.Add(exportedReport);

                if (reportIndex % 100 == 99)
                {
                    context.SaveChanges();
                }
            }

            context.SaveChanges();

            return createdReports;
        }
    }
}
