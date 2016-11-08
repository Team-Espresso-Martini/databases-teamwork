using ComputersFactory.Data.SQLite.Services.Contexts.Contracts;
using ComputersFactory.Data.SQLite.Services.UnitsOfWork.Contracts;

namespace ComputersFactory.Data.SQLite.Services.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISqLiteDbContext context;

        public UnitOfWork(ISqLiteDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.Commit();
        }

        public void Dispose()
        {
        }
    }
}
