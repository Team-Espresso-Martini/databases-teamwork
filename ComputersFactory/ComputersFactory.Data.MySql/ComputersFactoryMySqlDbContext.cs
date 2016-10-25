using System.Data.Entity;

using MySql.Data.Entity;
using ComputersFactory.Data.Contracts;

namespace ComputersFactory.Data.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ComputersFactoryMySqlDbContext : AbstractComputersFactoryDbContext
    {
        public ComputersFactoryMySqlDbContext()
            : base("MySqlConnection")
        {
        }
    }
}
