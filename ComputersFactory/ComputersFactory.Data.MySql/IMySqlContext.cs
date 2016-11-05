using ComputersFactory.Models;
using System.Data.Entity;

namespace ComputersFactory.Data.MySql
{
    public interface IMySqlDatabaseContext
    {
        IDbSet<MySqlReport> Reports { get; set; }

        int SaveChanges();
    }
}