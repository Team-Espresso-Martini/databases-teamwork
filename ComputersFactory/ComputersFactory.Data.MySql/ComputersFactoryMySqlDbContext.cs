using System.Data.Entity;

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
    }
}
