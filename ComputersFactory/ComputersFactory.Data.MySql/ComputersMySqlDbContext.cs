using System.Data.Entity;

using ComputersFactory.Models;
using ComputersFactory.Models.Components;

using MySql.Data.Entity;
using System.Data.Common;

namespace ComputersFactory.Data.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ComputersMySqlDbContext : DbContext
    {
        public ComputersMySqlDbContext()
            : base("MySqlConnection")
        {
        }

        // Constructor to use on a DbConnection that is already opened
        public ComputersMySqlDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        public virtual IDbSet<Memory> Memories { get; set; }

        public virtual IDbSet<Motherboard> MotherBoards { get; set; }

        public virtual IDbSet<Processor> Procesors { get; set; }

        public virtual IDbSet<VideoCard> VideoCards { get; set; }

        public virtual IDbSet<HardDrive> HardDrives { get; set; }

        public virtual IDbSet<Computer> Computers { get; set; }

        public virtual IDbSet<ComputerShop> ComputersShops { get; set; }
    }
}
