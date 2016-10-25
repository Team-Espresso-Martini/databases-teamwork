using System.Data.Entity;

using ComputersFactory.Models;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data.Contracts
{
    public interface IComputersFactoryDbContext
    {
        IDbSet<Memory> Memories { get; set; }

        IDbSet<Motherboard> MotherBoards { get; set; }

        IDbSet<Processor> Procesors { get; set; }

        IDbSet<VideoCard> VideoCards { get; set; }

        IDbSet<HardDrive> HardDrives { get; set; }

        IDbSet<Computer> Computers { get; set; }

        IDbSet<ComputerShop> ComputersShops { get; set; }

        int SaveChanges();
    }
}
