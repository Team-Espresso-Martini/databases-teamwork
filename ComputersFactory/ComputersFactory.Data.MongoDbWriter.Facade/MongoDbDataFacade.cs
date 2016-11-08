using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.Generator;
using ComputersFactory.Data.Models;
using ComputersFactory.Data.MongoDbWriter.Models;
using ComputersFactory.Data.MongoDbWriter.Models.Components;
using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.TransferToSql;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;

using MongoDB.Driver;

namespace ComputersFactory.Data.MongoDbWriter.Facade
{
    public class MongoDbDataFacade : IMongoDbDataFacade
    {
        private const string MongoDbHost = "mongodb://localhost";
        private const string MongoDbName = "ComputersFactory";

        private readonly AbstractComputersFactoryDbContext dbContext;

        public MongoDbDataFacade(AbstractComputersFactoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GenerateMongoDbData()
        {
            var mongoClient = new MongoClient(MongoDbHost);
            var mongoDatabase = mongoClient.GetDatabase(MongoDbName);

            var hardDrivesMongoRepository = new GenericMongoRepository<HardDriveMongoModel>(mongoDatabase);
            var memoriesMongoRepository = new GenericMongoRepository<MemoryMongoModel>(mongoDatabase);
            var motherboardsMongoRepository = new GenericMongoRepository<MotherboardMongoModel>(mongoDatabase);
            var processorsMongoRepository = new GenericMongoRepository<ProcessorMongoModel>(mongoDatabase);
            var videoCardsMongoRepository = new GenericMongoRepository<VideoCardMongoModel>(mongoDatabase);
            var computerShopsMongoRepository = new GenericMongoRepository<ComputerShopMongoModel>(mongoDatabase);
            var computersMongoRepository = new GenericMongoRepository<ComputerMongoModel>(mongoDatabase);

            var writer = new MongoDbWriter();
            writer.GenerateHardDrives(hardDrivesMongoRepository, RandomGenerator.Create);
            writer.GenerateMemories(memoriesMongoRepository, RandomGenerator.Create);
            writer.GenerateMotherboards(motherboardsMongoRepository, RandomGenerator.Create);
            writer.GenerateProcessors(processorsMongoRepository, RandomGenerator.Create);
            writer.GenerateVideoCards(videoCardsMongoRepository, RandomGenerator.Create);
            writer.GenerateComputerShops(computerShopsMongoRepository, RandomGenerator.Create);
            writer.GenerateComputers(hardDrivesMongoRepository, memoriesMongoRepository, motherboardsMongoRepository, processorsMongoRepository, videoCardsMongoRepository, computerShopsMongoRepository, computersMongoRepository, RandomGenerator.Create);
        }

        public void TransferDataFromMongoDbToSqlServer()
        {
            var mongoClient = new MongoClient(MongoDbHost);
            var mongoDatabase = mongoClient.GetDatabase(MongoDbName);

            var hardDrivesMongoRepository = new GenericMongoRepository<HardDriveMongoModel>(mongoDatabase);
            var memoriesMongoRepository = new GenericMongoRepository<MemoryMongoModel>(mongoDatabase);
            var motherboardsMongoRepository = new GenericMongoRepository<MotherboardMongoModel>(mongoDatabase);
            var processorsMongoRepository = new GenericMongoRepository<ProcessorMongoModel>(mongoDatabase);
            var videoCardsMongoRepository = new GenericMongoRepository<VideoCardMongoModel>(mongoDatabase);
            var computerShopsMongoRepository = new GenericMongoRepository<ComputerShopMongoModel>(mongoDatabase);
            var computersMongoRepository = new GenericMongoRepository<ComputerMongoModel>(mongoDatabase);

            var hardDrivesRepository = new GenericRepository<HardDrive>(dbContext);
            var memoriesRepository = new GenericRepository<Memory>(dbContext);
            var motherboardsRepository = new GenericRepository<Motherboard>(dbContext);
            var processorsRepository = new GenericRepository<Processor>(dbContext);
            var videoCardsRepository = new GenericRepository<VideoCard>(dbContext);
            var computerShopsRepository = new GenericRepository<ComputerShop>(dbContext);
            var computersRepository = new GenericRepository<Computer>(dbContext);


            var migrator = new MongoToSqlMigrator();
            migrator.TransferHardDriveDataToSQL(hardDrivesRepository, hardDrivesMongoRepository);
            dbContext.SaveChanges();

            migrator.TransferMemoryDataToSQL(memoriesRepository, memoriesMongoRepository);
            dbContext.SaveChanges();

            migrator.TransferMotherboardDataToSQL(motherboardsRepository, motherboardsMongoRepository);
            dbContext.SaveChanges();

            migrator.TransferProcessorDataToSQL(processorsRepository, processorsMongoRepository);
            dbContext.SaveChanges();

            migrator.TransferVideoCardDataToSQL(videoCardsRepository, videoCardsMongoRepository);
            dbContext.SaveChanges();

            migrator.TransferComputerShopDataToSQL(computerShopsRepository, computerShopsMongoRepository);
            dbContext.SaveChanges();

            migrator.TransferComputerDataToSQL(hardDrivesRepository, memoriesRepository, motherboardsRepository, processorsRepository, videoCardsRepository, computerShopsRepository, computersRepository, computersMongoRepository);
            dbContext.SaveChanges();
        }
    }
}
