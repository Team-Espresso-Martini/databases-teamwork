using System.Data.Entity;

using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.Repositories.Repositories
{
    public class ProcessorsRepository : GenericRepository<Computer>, IComputersRepository
    {
        public ProcessorsRepository(DbContext entityContext)
            : base(entityContext)
        {
        }
    }
}
