using System.Data.OleDb;

namespace ComputersFactory.Data.SalesReports.Excel.OleDb.Factories
{
    public interface IOleDbCommandFactory
    {
        OleDbCommand CreateOleDbCommand(string commandString);
    }
}
