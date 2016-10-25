using System.Data.Entity;

using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data.Repositories.Repositories
{
    public class MemoryRepository : GenericRepository<HardDrive>, IHardDrivesRepository
    {
        public MemoryRepository(DbContext entityContext)
            : base(entityContext)
        {
        }
    }
}
