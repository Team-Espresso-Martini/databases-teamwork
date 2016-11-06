using ComputersFactory.Data.Models;
using ComputersFactory.Data.SQLite.Services.Contexts.Contracts;
using ComputersFactory.Data.SQLite.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersFactory.Data.SQLite.Services.Contexts
{
    public class SqLiteComputersDbSet : ISqLiteDbSet<SqLiteComputer>
    {
        private const string ConnectionString = "Data Source=../../../../homework.sqlite;Version=3;";

        private readonly IConnectionFactory connectionFactory;
        private readonly ICommandFactory commandFactory;

        public SqLiteComputersDbSet(IConnectionFactory connectionFactory, ICommandFactory commandFactory)
        {
            this.connectionFactory = connectionFactory;
            this.commandFactory = commandFactory;
        }

        public void Add(SqLiteComputer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SqLiteComputer> All()
        {
            throw new NotImplementedException();
        }

        public void CreateTable()
        {
            throw new NotImplementedException();
        }

        public SqLiteComputer Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
