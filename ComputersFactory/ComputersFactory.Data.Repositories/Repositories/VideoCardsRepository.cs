using System.Data.Entity;

using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data.Repositories.Repositories
{
    public class VideoCardsRepository : GenericRepository<VideoCard>, IVideoCardsRepository
    {
        public VideoCardsRepository(DbContext entityContext)
            : base(entityContext)
        {
        }
    }
}
