using System;

using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Data.Repositories.UnitsOfWork.Contracts;
using ComputersFactory.Data.Repositories.Repositories;

namespace ComputersFactory.Data.Repositories.UnitsOfWork
{
    public class ComputersFactoryUnitOfWork : IUnitOfWork
    {
        private readonly AbstractComputersFactoryDbContext dbContext;

        public ComputersFactoryUnitOfWork(AbstractComputersFactoryDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;

            this.Computers = new ComputersRepository(dbContext);
            this.HardDrives = new HardDriveRespository(dbContext);
            this.Memory = new MemoryRepository(dbContext);
            this.Motherboards = new MotherboardsRepository(dbContext);
            this.Processors = new ProcessorsRepository(dbContext);
            this.VideoCards = new VideoCardsRepository(dbContext);
        }

        public IComputersRepository Computers { get; private set; }

        public IHardDrivesRepository HardDrives { get; private set; }

        public IMemoryRepository Memory { get; private set; }

        public IMotherboardsRepository Motherboards { get; private set; }

        public IProcessorsRepository Processors { get; private set; }

        public IVideoCardsRepository VideoCards { get; private set; }

        public int SaveChanges()
        {
            var rowsChanged = this.dbContext.SaveChanges();
            return rowsChanged;
        }
    }
}
