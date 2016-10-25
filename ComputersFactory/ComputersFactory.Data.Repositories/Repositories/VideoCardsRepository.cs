using System.Data.Entity;

using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.Repositories.Repositories
{
    public class VideoCardsRepository : GenericRepository<Computer>, IComputersRepository
    {
        public VideoCardsRepository(DbContext entityContext)
            : base(entityContext)
        {
        }
    }
}
