using System.Data.Entity;

using ComputersFactory.Models;

using MySql.Data.Entity;

namespace ComputersFactory.Data.MySql
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ComputersFactoryMySqlDbContext : DbContext, IMySqlDatabaseContext
    {
        public ComputersFactoryMySqlDbContext()
            : base("name=ComputersFactoryMySql")
        {
            Database.SetInitializer<ComputersFactoryMySqlDbContext>(null);
        }

        public virtual IDbSet<MySqlReport> Reports { get; set; }
    }
}
