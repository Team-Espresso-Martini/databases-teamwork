using System.Data.Entity;

using ComputersFactory.Models;
using ComputersFactory.Models.Components;
using ComputersFactory.Data.Models;

namespace ComputersFactory.Data.Contracts
{
    public abstract class AbstractComputersFactoryDbContext : DbContext, IComputersFactoryDbContext
    {
        protected AbstractComputersFactoryDbContext(string connectionStringName)
            : base(connectionStringName)
        {
        }

        public virtual IDbSet<Memory> Memories { get; set; }

        public virtual IDbSet<Motherboard> MotherBoards { get; set; }

        public virtual IDbSet<Processor> Procesors { get; set; }

        public virtual IDbSet<VideoCard> VideoCards { get; set; }

        public virtual IDbSet<HardDrive> HardDrives { get; set; }

        public virtual IDbSet<Computer> Computers { get; set; }

        public virtual IDbSet<ComputerShop> ComputersShops { get; set; }

        public virtual IDbSet<SalesReport> SalesReports { get; set; }
    }
}
