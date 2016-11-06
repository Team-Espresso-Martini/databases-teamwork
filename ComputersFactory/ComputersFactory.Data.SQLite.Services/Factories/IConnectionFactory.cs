using System.Data.SQLite;

namespace ComputersFactory.Data.SQLite.Services.Factories
{
    public interface IConnectionFactory
    {
        SQLiteConnection CreateSQLiteConnection(string connectionString);
    }
}
