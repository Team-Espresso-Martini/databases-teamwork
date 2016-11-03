namespace ComputersFactory.Data.SalesReports.DataImporter.Contracts
{
    public interface IXmlDataImporter
    {
        void ImportData(string fileName, string rootElement);
    }
}
