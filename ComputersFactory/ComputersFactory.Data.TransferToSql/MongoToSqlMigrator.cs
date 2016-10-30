using ComputersFactory.Data.Models;
using ComputersFactory.Data.MongoDbWriter.Models;
using ComputersFactory.Data.MongoDbWriter.Models.Components;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;
using MongoDB.Driver;
using System.Linq;

namespace ComputersFactory.Data.TransferToSql
{
    public class MongoToSqlMigrator
    {
        public static void TransferData()
        {
            string mongoDbHost = "mongodb://localhost";
            string mongoDbName = "ComputersFactory";

            var mongoClient = new MongoClient(mongoDbHost);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbName);
            var context = new ComputersFactoryDbContext();

            TransferHardDriveDataToSQL(context, mongoDatabase);
            TransferMemoryDataToSQL(context, mongoDatabase);
            TransferMotherboardDataToSQL(context, mongoDatabase);
            TransferProcessorDataToSQL(context, mongoDatabase);
            TransferVideoCardDataToSQL(context, mongoDatabase);
            TransferComputerShopDataToSQL(context, mongoDatabase);
            context.SaveChanges();
            //TransferComputerDataToSQL(context, mongoDatabase);
        }

        private static void TransferHardDriveDataToSQL(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var mongoHardDrives = mongoDatabase.GetCollection<HardDriveMongoModel>("HardDrives").AsQueryable().ToList();
            foreach (var mongoHdd in mongoHardDrives)
            {
                //var computersCollection = new HashSet<Computer>();
                //var computers = mongoHdd.Computers.ToList();
                //foreach (var computer in computers)
                //{
                //    computersCollection.Add(
                //        new Computer
                //        {
                //            Model = computer.Model,
                //            Price = computer.Price,
                //            MemoryId = computer.MemoryId,
                //            MotherboardId = computer.MotherboardId,
                //            ProcesorId = computer.ProcesorId,
                //            VideocardId = computer.VideocardId,
                //            ComputerShopId = computer.ComputerShopId,
                //            HardDrives = new HashSet<HardDrive>()
                //        });
                //}

                context.HardDrives.Add(
                    new HardDrive
                    {
                        Model = mongoHdd.Model,
                        Price = mongoHdd.Price,
                        CapacityInGb = mongoHdd.CapacityInGb,
                        Manufacturer = mongoHdd.Manufacturer
                    });
            }
        }

        private static void TransferMemoryDataToSQL(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var mongoMemories = mongoDatabase.GetCollection<MemoryMongoModel>("Memories").AsQueryable().ToList();
            foreach (var mongoMemory in mongoMemories)
            {
                context.Memories.Add(
                    new Memory
                    {
                        CapacityInGb = mongoMemory.CapacityInGb,
                        Price = mongoMemory.Price,
                        Manufacturer = mongoMemory.Manufacturer
                    });
            }
        }

        private static void TransferMotherboardDataToSQL(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var mongoMotherboards = mongoDatabase.GetCollection<MotherboardMongoModel>("Motherboards").AsQueryable().ToList();
            foreach (var mongoMotherboard in mongoMotherboards)
            {
                context.MotherBoards.Add(
                    new Motherboard
                    {
                        Model = mongoMotherboard.Model,
                        Price = mongoMotherboard.Price,
                        Manufacturer = mongoMotherboard.Manufacturer
                    });
            }
        }

        private static void TransferProcessorDataToSQL(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var mongoProcessors = mongoDatabase.GetCollection<ProcessorMongoModel>("Processors").AsQueryable().ToList();
            foreach (var mongoProcessor in mongoProcessors)
            {
                context.Procesors.Add(
                    new Processor
                    {
                        Model = mongoProcessor.Model,
                        Price = mongoProcessor.Price,
                        FrequencyInMhz = mongoProcessor.FrequencyInMhz,
                        Manufacturer = mongoProcessor.Manufacturer
                    });
            }
        }

        private static void TransferVideoCardDataToSQL(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var mongoVideoCards = mongoDatabase.GetCollection<VideoCardMongoModel>("VideoCards").AsQueryable().ToList();
            foreach (var mongoVideoCard in mongoVideoCards)
            {
                context.VideoCards.Add(
                    new VideoCard
                    {
                        Model = mongoVideoCard.Model,
                        Price = mongoVideoCard.Price,
                        Manufacturer = mongoVideoCard.Manufacturer
                    });
            }
        }

        private static void TransferComputerDataToSQL(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var mongoComputers = mongoDatabase.GetCollection<ComputerMongoModel>("Computers").AsQueryable().ToList();
            foreach (var mongoComputer in mongoComputers)
            {
                //var mongoHdds = mongoComputer.HardDrivesIds.ToList();
                //var hddCollection = new HashSet<HardDrive>()
                //{
                //    context.HardDrives.Where(h => h.Id == mongoHdds[0]).FirstOrDefault(),
                //    context.HardDrives.Where(h => h.Id == mongoHdds[1]).FirstOrDefault()
                //};

                context.Computers.Add(
                    new Computer
                    {
                        Model = mongoComputer.Model,
                        Price = mongoComputer.Price,
                        MemoryId = mongoComputer.MemoryId,
                        MotherboardId = mongoComputer.MotherboardId,
                        ProcesorId = mongoComputer.ProcesorId,
                        VideocardId = mongoComputer.VideocardId,
                        ComputerShopId = mongoComputer.ComputerShopId
                        //HardDrives = hddCollection
                    });
            }
        }

        private static void TransferComputerShopDataToSQL(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var mongoComputerShops = mongoDatabase.GetCollection<ComputerShopMongoModel>("ComputerShops").AsQueryable().ToList();
            foreach (var mongoShop in mongoComputerShops)
            {
                context.ComputersShops.Add(
                    new ComputerShop
                    {
                        Name = mongoShop.Name
                    });
            }
        }
    }
}
