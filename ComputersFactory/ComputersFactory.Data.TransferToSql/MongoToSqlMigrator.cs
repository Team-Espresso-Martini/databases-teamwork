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

            // If we don't save changes before transfering the computers, there are going to be some FK issues.
            TransferComputerDataToSQL(context, mongoDatabase);
            context = RefreshContext(context);

            AddComputersSetToHardDrives(context, mongoDatabase);
            context = RefreshContext(context);

            AddComputersSetToMemories(context, mongoDatabase);
            context = RefreshContext(context);

            AddComputersSetToMotherboards(context, mongoDatabase);
            context = RefreshContext(context);

            AddComputersSetToProcessors(context, mongoDatabase);
            context = RefreshContext(context);

            AddComputersSetToVideoCards(context, mongoDatabase);
            context = RefreshContext(context);

            AddComputersSetToVideoCards(context, mongoDatabase);
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
            var memories = context.Memories.ToList();
            var motherboards = context.MotherBoards.ToList();
            var processors = context.Procesors.ToList();
            var videoCards = context.VideoCards.ToList();
            var computerShops = context.ComputersShops.ToList();

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
                        MemoryId = memories[mongoComputer.MemoryId].Id,
                        MotherboardId = motherboards[mongoComputer.MotherboardId].Id,
                        ProcesorId = processors[mongoComputer.ProcesorId].Id,
                        VideocardId = videoCards[mongoComputer.VideocardId].Id,
                        ComputerShopId = computerShops[mongoComputer.ComputerShopId].Id
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

        private static void AddComputersSetToHardDrives(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var hardDrives = context.HardDrives.ToList();
            var mongoHardDrives = mongoDatabase.GetCollection<HardDriveMongoModel>("HardDrives").AsQueryable().ToList();
            var mongoHddComputers = mongoHardDrives.Select(h => h.Computers).ToList();
            for (int i = 0; i < mongoHddComputers.Count; i++)
            {
                foreach (var mongoComputer in mongoHddComputers[i])
                {
                    hardDrives[i].Computers.Add(CreateNewComputer(mongoComputer));
                }
            }
        }

        private static void AddComputersSetToMemories(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var memories = context.Memories.ToList();
            var mongoMemories = mongoDatabase.GetCollection<MemoryMongoModel>("Memories").AsQueryable().ToList();
            var mongoMemoriesComputers = mongoMemories.Select(m => m.Computers).ToList();
            for (int i = 0; i < mongoMemoriesComputers.Count; i++)
            {
                foreach (var mongoComputer in mongoMemoriesComputers[i])
                {
                    memories[i].Computers.Add(CreateNewComputer(mongoComputer));
                }
            }
        }

        private static void AddComputersSetToMotherboards(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var motherboards = context.MotherBoards.ToList();
            var mongoMotherboards = mongoDatabase.GetCollection<MotherboardMongoModel>("MotherBoards").AsQueryable().ToList();
            var mongoMotherboardsComputers = mongoMotherboards.Select(m => m.Computers).ToList();
            for (int i = 0; i < mongoMotherboardsComputers.Count; i++)
            {
                foreach (var mongoComputer in mongoMotherboardsComputers[i])
                {
                    motherboards[i].Computers.Add(CreateNewComputer(mongoComputer));
                }
            }
        }

        private static void AddComputersSetToProcessors(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var processors = context.Procesors.ToList();
            var mongoProcessors = mongoDatabase.GetCollection<ProcessorMongoModel>("Processors").AsQueryable().ToList();
            var mongoProcessorsComputers = mongoProcessors.Select(m => m.Computers).ToList();
            for (int i = 0; i < mongoProcessorsComputers.Count; i++)
            {
                foreach (var mongoComputer in mongoProcessorsComputers[i])
                {
                    processors[i].Computers.Add(CreateNewComputer(mongoComputer));
                }
            }
        }

        private static void AddComputersSetToVideoCards(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var videoCards = context.VideoCards.ToList();
            var mongoVideoCards = mongoDatabase.GetCollection<VideoCardMongoModel>("VideoCards").AsQueryable().ToList();
            var mongoVideoCardsComputers = mongoVideoCards.Select(m => m.Computers).ToList();
            for (int i = 0; i < mongoVideoCardsComputers.Count; i++)
            {
                foreach (var mongoComputer in mongoVideoCardsComputers[i])
                {
                    videoCards[i].Computers.Add(CreateNewComputer(mongoComputer));
                }
            }
        }

        private static void AddComputersSetToComputerShops(ComputersFactoryDbContext context, IMongoDatabase mongoDatabase)
        {
            var computerShops = context.ComputersShops.ToList();
            var mongoComputerShops = mongoDatabase.GetCollection<ComputerShopMongoModel>("ComputerShops").AsQueryable().ToList();
            var mongoComputerShopsComputers = mongoComputerShops.Select(m => m.Computers).ToList();
            for (int i = 0; i < mongoComputerShopsComputers.Count; i++)
            {
                foreach (var mongoComputer in mongoComputerShopsComputers[i])
                {
                    computerShops[i].Computers.Add(CreateNewComputer(mongoComputer));
                }
            }
        }

        private static Computer CreateNewComputer(ComputerMongoModel mongoComputer)
        {
            return new Computer
            {
                Model = mongoComputer.Model,
                Price = mongoComputer.Price,
                MemoryId = mongoComputer.MemoryId,
                MotherboardId = mongoComputer.MotherboardId,
                ProcesorId = mongoComputer.ProcesorId,
                VideocardId = mongoComputer.VideocardId,
                ComputerShopId = mongoComputer.ComputerShopId
            };
        }
    }
}
