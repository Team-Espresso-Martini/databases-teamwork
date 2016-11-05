using System.Data.Entity;

using ComputersFactory.Data;
using ComputersFactory.Data.Migrations;
using ComputersFactory.Data.MongoDbWriter;
using ComputersFactory.Data.Repositories.UnitsOfWork;
using ComputersFactory.Data.TransferToSql;
using MongoDB.Driver;
using ComputersFactory.Data.Repositories.Repositories.Base;
using ComputersFactory.Data.MongoDbWriter.Models.Components;
using ComputersFactory.Data.MongoDbWriter.Models;

namespace ComputersFactory.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputersFactoryDbContext, Configuration>());

            var db = new ComputersFactoryDbContext();
            var worker = new ComputersFactoryUnitOfWork(db);

            //MongoToSqlMigrator.TransferData();

            string dbHost = "mongodb://localhost";
            string dbName = "ComputersFactory";

            var client = new MongoClient(dbHost);
            var database = client.GetDatabase(dbName);

            var hardDrivesRepository = new GenericMongoRepository<HardDriveMongoModel>(database);
            var memoriesRepository = new GenericMongoRepository<MemoryMongoModel>(database);
            var motherboardsRepository = new GenericMongoRepository<MotherboardMongoModel>(database);
            var processorsRepository = new GenericMongoRepository<ProcessorMongoModel>(database);
            var videoCardsRepository = new GenericMongoRepository<VideoCardMongoModel>(database);
            var computerShopsRepository = new GenericMongoRepository<ComputerShopMongoModel>(database);
            var computersRepository = new GenericMongoRepository<ComputerMongoModel>(database);

            var writer = new MongoDbWriter();
            writer.GenerateHardDrives(hardDrivesRepository);
            writer.GenerateMemories(memoriesRepository);
            writer.GenerateMotherboards(motherboardsRepository);
            writer.GenerateProcessors(processorsRepository);
            writer.GenerateVideoCards(videoCardsRepository);
            writer.GenerateComputerShops(computerShopsRepository);
            writer.GenerateComputers(hardDrivesRepository, memoriesRepository, motherboardsRepository, processorsRepository, videoCardsRepository, computerShopsRepository, computersRepository);
        }
    }
}
