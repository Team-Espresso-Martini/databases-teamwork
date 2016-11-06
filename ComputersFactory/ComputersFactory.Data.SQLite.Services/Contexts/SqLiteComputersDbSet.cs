using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.SQLite.Services.Contexts.Contracts;
using ComputersFactory.Data.SQLite.Services.Factories;

namespace ComputersFactory.Data.SQLite.Services.Contexts
{
    public class SqLiteComputersDbSet : ISqLiteDbSet<SqLiteComputer>
    {
        private const string ConnectionString = @"Data Source=D:\TeamWorkFiles\SqLiteDb\sqlitedb.sqlite;Version=3;";
        private const string TableName = "SqLiteComputers";

        private readonly IConnectionFactory connectionFactory;
        private readonly ICommandFactory commandFactory;
        
        public SqLiteComputersDbSet(IConnectionFactory connectionFactory, ICommandFactory commandFactory)
        {
            this.connectionFactory = connectionFactory;
            this.commandFactory = commandFactory;
        }
        
        public void Add(SqLiteComputer entity)
        {
            var query =
                "INSERT INTO " + SqLiteComputersDbSet.TableName +
                $" VALUES ({entity.Model}, {entity.Price}, {entity.Rating})";

            var command = this.commandFactory.CreateSQLiteCommand(query);
            var connection = this.connectionFactory.CreateSQLiteConnection(ConnectionString);
            command.Connection = connection;

            connection.Open();
            using (connection)
            {
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<SqLiteComputer> All()
        {
            var query =
                "SELECT *" +
                "FROM " + SqLiteComputersDbSet.TableName;

            var command = this.commandFactory.CreateSQLiteCommand(query);
            var connection = this.connectionFactory.CreateSQLiteConnection(ConnectionString);
            command.Connection = connection;

            connection.Open();
            using (connection)
            {
                var reader = command.ExecuteReader();

                var result = new List<SqLiteComputer>();
                while (reader.Read())
                {
                    var nextInstance = new SqLiteComputer();
                    nextInstance.Id = (int)reader["Id"];
                    nextInstance.Model = (string)reader["Model"];
                    nextInstance.Price = (decimal)reader["Price"];
                    nextInstance.Rating = (int)reader["Rating"];

                    result.Add(nextInstance);
                }

                return result;
            }
        }

        public void CreateTable()
        {
            var query =
                "CREATE TABLE SqLiteComputers( " +
                    "Id INT PRIMARY KEY IDENTITY," +
                    "Model NVARCHAR(50)," +
                    "Price MONEY, " +
                    "Rating INT" +
                    ")";

            var command = this.commandFactory.CreateSQLiteCommand(query);
            var connection = this.connectionFactory.CreateSQLiteConnection(ConnectionString);
            command.Connection = connection;

            connection.Open();
            using (connection)
            {
                command.ExecuteNonQuery();
            }
        }

        public SqLiteComputer Find(int id)
        {
            var query =
               "SELECT *" +
               "FROM " + SqLiteComputersDbSet.TableName +
               " WHERE Id = " + id.ToString();

            var command = this.commandFactory.CreateSQLiteCommand(query);
            var connection = this.connectionFactory.CreateSQLiteConnection(ConnectionString);
            command.Connection = connection;

            connection.Open();
            using (connection)
            {
                var reader = command.ExecuteReader();

                var result = new List<SqLiteComputer>();
                while (reader.Read())
                {
                    var nextInstance = new SqLiteComputer();
                    nextInstance.Id = (int)reader["Id"];
                    nextInstance.Model = (string)reader["Model"];
                    nextInstance.Price = (decimal)reader["Price"];
                    nextInstance.Rating = (int)reader["Rating"];

                    result.Add(nextInstance);
                }

                return result.FirstOrDefault();
            }
        }
    }
}
