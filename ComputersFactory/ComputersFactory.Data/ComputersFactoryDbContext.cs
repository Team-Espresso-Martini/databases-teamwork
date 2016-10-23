using System.Data.Entity;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data
{
    public class ComputersFactoryDbContext : DbContext
    {
        public ComputersFactoryDbContext():base("ComputersFactoryConnection")
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
