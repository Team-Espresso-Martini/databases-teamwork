using System.Linq;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.MongoDbWriter.Models;
using ComputersFactory.Data.MongoDbWriter.Models.Components;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;

using MongoDB.Driver;

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
            context = RefreshContext(context);

            TransferMemoryDataToSQL(context, mongoDatabase);
            context = RefreshContext(context);

            TransferMotherboardDataToSQL(context, mongoDatabase);
            context = RefreshContext(context);

            TransferProcessorDataToSQL(context, mongoDatabase);
            context = RefreshContext(context);

            TransferVideoCardDataToSQL(context, mongoDatabase);
            context = RefreshContext(context);

            TransferComputerShopDataToSQL(context, mongoDatabase);
            context = RefreshContext(context);

            TransferComputerDataToSQL(context, mongoDatabase);
            context = RefreshContext(context);
        }

        private static ComputersFactoryDbContext RefreshContext(ComputersFactoryDbContext context)
        {
            context.SaveChanges();
            context = new ComputersFactoryDbContext();
            return context;
        }

        private static void TransferHardDriveDataToSQL(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var mongoHardDrives = mongoDatabase.GetCollection<HardDriveMongoModel>("HardDrives").AsQueryable().ToList();
            foreach (var mongoHdd in mongoHardDrives)
            {
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
                context.Computers.Add(
                    new Computer
                    {
                        Model = mongoComputer.Model,
                        Price = mongoComputer.Price,
                        Memory = new Memory
                        {
                            Manufacturer = mongoComputer.Memory.Manufacturer,
                            Price = mongoComputer.Memory.Price,
                            CapacityInGb = mongoComputer.Memory.CapacityInGb
                        },
                        Motherboard = new Motherboard
                        {
                            Manufacturer = mongoComputer.Motherboard.Manufacturer,
                            Model = mongoComputer.Motherboard.Model,
                            Price = mongoComputer.Motherboard.Price
                        },
                        Processor = new Processor
                        {
                            Model = mongoComputer.Processor.Model,
                            Manufacturer = mongoComputer.Processor.Manufacturer,
                            Price = mongoComputer.Processor.Price,
                            FrequencyInMhz = mongoComputer.Processor.FrequencyInMhz
                        },
                        Videocard = new VideoCard
                        {
                            Model = mongoComputer.Videocard.Model,
                            Manufacturer = mongoComputer.Videocard.Manufacturer,
                            Price = mongoComputer.Videocard.Price
                        },
                        ComputerShop = new ComputerShop
                        {
                            Name = mongoComputer.ComputerShop.Name
                        }
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

        private static Computer CreateNewComputer(ComputerMongoModel mongoComputer)
        {
            return new Computer
            {
                Model = mongoComputer.Model,
                Price = mongoComputer.Price
            };
        }
    }
}
