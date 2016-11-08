using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.SQLite.Services.Contexts.Contracts;
using ComputersFactory.Data.SQLite.Services.Repositories.Contracts;

namespace ComputersFactory.Data.SQLite.Services.Repositories
{
    public class SqLiteComputerRepository : IRepository<SqLiteComputer>
    {
        private readonly ISqLiteDbContext context;

        public SqLiteComputerRepository(ISqLiteDbContext context)
        {
            this.context = context;
        }

        public void Add(SqLiteComputer entity)
        {
            this.context.Computers.Add(entity);
        }

        public IEnumerable<SqLiteComputer> All()
        {
            return this.context.Computers.All().ToList();
        }

        public SqLiteComputer Find(int id)
        {
            return this.context.Computers.Find(id);
        }
    }
}
