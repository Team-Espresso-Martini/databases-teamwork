namespace ComputersFactory.Data.SalesReports.DataImporter.Contracts
{
    public interface IXmlDataImporter<TModelIn, TModelOut>
    {
        void ImportData(string fileName, string rootElement);
    }
}
