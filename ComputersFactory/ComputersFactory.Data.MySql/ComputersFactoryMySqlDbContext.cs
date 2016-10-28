using System.Data.Entity;

using MySql.Data.Entity;
<<<<<<< HEAD
using ComputersFactory.Data.Models;
=======
using ComputersFactory.Data.Contracts;
>>>>>>> 17418bae6717a3272d3c082a8dbb85bbafcbb37b

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
