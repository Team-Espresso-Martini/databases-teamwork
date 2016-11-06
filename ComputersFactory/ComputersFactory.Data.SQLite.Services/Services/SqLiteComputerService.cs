using System;
using System.Collections.Generic;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.SQLite.Services.Repositories.Contracts;
using ComputersFactory.Data.SQLite.Services.Services.Contracts;

namespace ComputersFactory.Data.SQLite.Services.Services
{
    public class SqLiteComputerService : ISqLiteComputerService
    {
        private readonly IRepository<SqLiteComputer> repository;

        public SqLiteComputerService(IRepository<SqLiteComputer> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<SqLiteComputer> CreateSqLiteComputers(IEnumerable<Computer> computers)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SqLiteComputer> GetAllSqLiteComputers()
        {
            return this.repository.All();
        }
    }
}
