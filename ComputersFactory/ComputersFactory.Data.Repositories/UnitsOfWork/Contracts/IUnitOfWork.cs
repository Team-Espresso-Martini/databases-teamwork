using ComputersFactory.Data.Repositories.Repositories.Contracts;

namespace ComputersFactory.Data.Repositories.UnitsOfWork.Contracts
{
    public interface IUnitOfWork
    {
        IComputersRepository Computers { get; }

        IHardDrivesRepository HardDrives { get; }

        IMemoryRepository Memory { get; }

        IMotherboardsRepository Motherboards { get; }

        IProcessorsRepository Processors { get; }

        IVideoCardsRepository VideoCards { get; }
    }
}
