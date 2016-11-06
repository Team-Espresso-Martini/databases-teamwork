using ComputersFactory.Data.Models;

namespace ComputersFactory.Data.SQLite.Services.Contexts.Contracts
{
    public interface ISqLiteDbContext
    {
        ISqLiteDbSet<SqLiteComputer> Computers { get; set; }

        void Commit();
    }
}
