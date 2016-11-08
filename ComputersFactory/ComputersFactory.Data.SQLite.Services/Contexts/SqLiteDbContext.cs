using System;

using ComputersFactory.Data.SQLite.Services.Contexts.Contracts;
using ComputersFactory.Data.Models;
using ComputersFactory.Data.SQLite.Services.Factories;

namespace ComputersFactory.Data.SQLite.Services.Contexts
{
    public class SqLiteDbContext : ISqLiteDbContext
    {
        private readonly IConnectionFactory connectionFactory;

        private ISqLiteDbSet<SqLiteComputer> computers;

        public SqLiteDbContext(IConnectionFactory connectionFactory, ISqLiteDbSet<SqLiteComputer> computers)
        {
            this.connectionFactory = connectionFactory;
            this.computers = computers;
        }

        public ISqLiteDbSet<SqLiteComputer> Computers
        {
            get
            {
                return this.computers;
            }

            set
            {
                this.computers = value;
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
