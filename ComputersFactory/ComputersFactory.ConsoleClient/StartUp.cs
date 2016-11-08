using System.Data.Entity;

using ComputersFactory.Data;
using ComputersFactory.Data.Migrations;
using ComputersFactory.Data.MongoDbWriter;
using ComputersFactory.Data.Repositories.UnitsOfWork;
using ComputersFactory.Data.TransferToSql;
using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.MongoDbWriter.Models.Components;
using ComputersFactory.Data.MongoDbWriter.Models;
using ComputersFactory.Models.Components;
using ComputersFactory.Models;
using ComputersFactory.Data.Models;
using ComputersFactory.Data.Generator;

using MongoDB.Driver;

namespace ComputersFactory.ConsoleClient
{
    public class StartUp
    {
        private const string MongoDbHost = "mongodb://localhost";
        private const string MongoDbName = "ComputersFactory";

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersFactoryDbContext, Configuration>());

            var dbContext = new ComputersFactoryDbContext();
            var worker = new ComputersFactoryUnitOfWork(dbContext);

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
            var randomGenerator = RandomGenerator.Create;
            writer.GenerateHardDrives(hardDrivesMongoRepository, randomGenerator);
            writer.GenerateMemories(memoriesMongoRepository, randomGenerator);
            writer.GenerateMotherboards(motherboardsMongoRepository, randomGenerator);
            writer.GenerateProcessors(processorsMongoRepository, randomGenerator);
            writer.GenerateVideoCards(videoCardsMongoRepository, randomGenerator);
            writer.GenerateComputerShops(computerShopsMongoRepository, randomGenerator);
            writer.GenerateComputers(hardDrivesMongoRepository, memoriesMongoRepository, motherboardsMongoRepository, processorsMongoRepository, videoCardsMongoRepository, computerShopsMongoRepository, computersMongoRepository, randomGenerator);

            var hardDrivesRepository = new GenericRepository<HardDrive>(dbContext);
            var memoriesRepository = new GenericRepository<Memory>(dbContext);
            var motherboardsRepository = new GenericRepository<Motherboard>(dbContext);
            var processorsRepository = new GenericRepository<Processor>(dbContext);
            var videoCardsRepository = new GenericRepository<VideoCard>(dbContext);
            var computerShopsRepository = new GenericRepository<ComputerShop>(dbContext);
            var computersRepository = new GenericRepository<Computer>(dbContext);


            var migrator = new MongoToSqlMigrator();
            migrator.TransferHardDriveDataToSQL(hardDrivesRepository, hardDrivesMongoRepository);
            RefreshContext(dbContext);

            migrator.TransferMemoryDataToSQL(memoriesRepository, memoriesMongoRepository);
            RefreshContext(dbContext);

            migrator.TransferMotherboardDataToSQL(motherboardsRepository, motherboardsMongoRepository);
            RefreshContext(dbContext);

            migrator.TransferProcessorDataToSQL(processorsRepository, processorsMongoRepository);
            RefreshContext(dbContext);

            migrator.TransferVideoCardDataToSQL(videoCardsRepository, videoCardsMongoRepository);
            RefreshContext(dbContext);

            migrator.TransferComputerShopDataToSQL(computerShopsRepository, computerShopsMongoRepository);
            RefreshContext(dbContext);

            migrator.TransferComputerDataToSQL(hardDrivesRepository, memoriesRepository, motherboardsRepository, processorsRepository, videoCardsRepository, computerShopsRepository, computersRepository, computersMongoRepository);
            RefreshContext(dbContext);
        }

        private static ComputersFactoryDbContext RefreshContext(ComputersFactoryDbContext context)
        {
            context.SaveChanges();
            context = new ComputersFactoryDbContext();

            return context;
        }
    }
}
