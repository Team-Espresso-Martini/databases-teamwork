using System.Data.OleDb;

namespace ComputersFactory.Data.SalesReports.Excel.OleDb.Factories
{
    public interface IOleDbConnectionFactory
    {
        OleDbConnection CreateOleDbConnection(string connectionString);
    }
}
