using System;

using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.SalesReports.Converters.Contracts;
using ComputersFactory.Data.SalesReports.DataImporter.Contracts;
using ComputersFactory.Data.SalesReports.XmlModels;
using ComputersFactory.Data.SalesReports.XmlDeserializers.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.SalesReports.DataImporter
{
    public class XmlSalesReportDataImporter : IXmlDataImporter<XmlSalesReport, SalesReport>
    {
        private readonly IXmlDeserializer xmlDeserializer;
        private readonly IModelConverter modelConverter;
        private readonly AbstractComputersFactoryDbContext context;

        public XmlSalesReportDataImporter(IXmlDeserializer xmlDeserializer, IModelConverter modelConverter, AbstractComputersFactoryDbContext context)
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

        public void ImportData(string fileName, string rootElement)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrEmpty(rootElement))
            {
                throw new ArgumentNullException(nameof(rootElement));
            }

            var salesReportsFromXml = this.xmlDeserializer.DeserializeXmlTo<XmlSalesReport>(fileName, rootElement);
            var salesReportsWithoutNestedCollection = this.modelConverter.Convert<XmlSalesReport, SalesReport>(salesReportsFromXml);

            var reportsCount = salesReportsFromXml.Count;
            for (int reportIndex = 0; reportIndex < reportsCount; reportIndex++)
            {
                var importedReport = salesReportsFromXml[reportIndex];
                var exportedReport = salesReportsWithoutNestedCollection[reportIndex];

                var sales = this.modelConverter.Convert<XmlSale, Sale>(importedReport.Sales);
                exportedReport.Sales = sales;

                this.context.SalesReports.Add(exportedReport);

                if (reportIndex % 100 == 1)
                {
                    context.SaveChanges();
                }
            }

            context.SaveChanges();
        }
    }
}
