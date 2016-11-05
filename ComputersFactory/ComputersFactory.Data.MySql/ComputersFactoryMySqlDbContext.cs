using System.Data.Entity;

using ComputersFactory.Models;

using MySql.Data.Entity;

namespace ComputersFactory.Data.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ComputersFactoryMySqlDbContext : DbContext, IMySqlDatabaseContext
    {
        public ComputersFactoryMySqlDbContext()
            : base("name=ComputersFactoryMySql")
        {
        }

        public virtual IDbSet<MySqlReport> Reports { get; set; }
    }
}
