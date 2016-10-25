using System;

using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Data.Repositories.UnitsOfWork.Contracts;

namespace ComputersFactory.Data.Repositories.UnitsOfWork
{
    public class ComputersFactoryUnitOfWork : IUnitOfWork
    {
        public ComputersFactoryUnitOfWork()
        {

        }

        public IComputersRepository Computers { get; private set; }

        public IHardDrivesRepository HardDrives { get; private set; }

        public IMemoryRepository Memory { get; private set; }

        public IMotherboardsRepository Motherboards { get; private set; }

        public IProcessorsRepository Processors { get; private set; }

        public IVideoCardsRepository VideoCards { get; private set; }
    }
}
