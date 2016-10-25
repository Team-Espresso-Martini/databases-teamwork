using System.Data.Entity;

using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data.Repositories.Repositories
{
    public class MotherboardsRepository : GenericRepository<Motherboard>, IMotherboardsRepository
    {
        public MotherboardsRepository(DbContext entityContext)
            : base(entityContext)
        {
        }
    }
}
