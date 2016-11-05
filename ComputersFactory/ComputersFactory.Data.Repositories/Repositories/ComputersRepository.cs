using System.Data.Entity;

using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Models;
using ComputersFactory.Data.Models;

namespace ComputersFactory.Data.Repositories.Repositories
{
    public class ComputersRepository : GenericRepository<Computer>, IComputersRepository
    {
        public ComputersRepository(DbContext context)
            : base(context)
        {
        }
    }
}
