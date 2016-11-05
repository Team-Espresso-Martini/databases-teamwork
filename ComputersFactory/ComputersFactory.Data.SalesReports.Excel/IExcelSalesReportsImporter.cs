namespace ComputersFactory.Data.SalesReports.Excel
{
    public interface IExcelSalesReportsImporter
    {
        void ImportSalesReportsFromExcel(string fileName, string tempFileName);
    }
}