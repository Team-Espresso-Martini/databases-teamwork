using System.Data.SQLite;

namespace ComputersFactory.Data.SQLite.Services.Factories
{
    public interface ICommandFactory
    {
        SQLiteCommand CreateSQLiteCommand(string commandText);
    }
}
