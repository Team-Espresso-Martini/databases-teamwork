using System.Data.Entity;

using ComputersFactory.Data.SQLite.Models;

namespace ComputersFactory.Data.SQLite.Connection
{
    public class SqLiteDbContext : DbContext
    {
        public SqLiteDbContext()
            : base("name=SqLiteComputersDb")
        {
            //Database.SetInitializer<SqLiteDbContext>(null);
        }

        public virtual IDbSet<SqLiteComputer> Computers { get; set; }
    }
}
