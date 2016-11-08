using System;

using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Data.Repositories.UnitsOfWork.Contracts;
using ComputersFactory.Data.Models;
using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Models.Components;
using ComputersFactory.Models;

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

            this.Computers = new GenericRepository<Computer>(dbContext);
            this.HardDrives = new GenericRepository<HardDrive>(dbContext);
            this.Memory = new GenericRepository<Memory>(dbContext);
            this.Motherboards = new GenericRepository<Motherboard>(dbContext);
            this.Processors = new GenericRepository<Processor>(dbContext);
            this.VideoCards = new GenericRepository<VideoCard>(dbContext);
            this.ComputerShops = new GenericRepository<ComputerShop>(dbContext);
        }

        public IRepository<Computer> Computers { get; private set; }

        public IRepository<HardDrive> HardDrives { get; private set; }

        public IRepository<Memory> Memory { get; private set; }

        public IRepository<Motherboard> Motherboards { get; private set; }

        public IRepository<Processor> Processors { get; private set; }

        public IRepository<VideoCard> VideoCards { get; private set; }

        public IRepository<ComputerShop> ComputerShops { get; private set; }

        public int SaveChanges()
        {
            var rowsChanged = this.dbContext.SaveChanges();
            return rowsChanged;
        }
    }
}
