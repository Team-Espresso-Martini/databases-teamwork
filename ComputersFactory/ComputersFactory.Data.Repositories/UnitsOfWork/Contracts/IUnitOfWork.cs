using ComputersFactory.Data.Models;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data.Repositories.UnitsOfWork.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Computer> Computers { get; }

        IRepository<HardDrive> HardDrives { get; }

        IRepository<Memory> Memory { get; }

        IRepository<Motherboard> Motherboards { get; }

        IRepository<Processor> Processors { get; }

        IRepository<VideoCard> VideoCards { get; }

        IRepository<ComputerShop> ComputerShops { get; }

        int SaveChanges();
    }
}
