using System.Linq;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.MongoDbWriter.Models;
using ComputersFactory.Data.MongoDbWriter.Models.Components;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;

using MongoDB.Driver;
using ComputersFactory.Data.Repositories.Repositories.Contracts;

namespace ComputersFactory.Data.TransferToSql
{
    public class MongoToSqlMigrator
    {
        public void TransferHardDriveDataToSQL(IRepository<HardDrive> hardDrivesRepository, IMongoRepository<HardDriveMongoModel> hardDrivesMongoRepository)
        {
            var hardDrivesMongoCollection = hardDrivesMongoRepository.GetAll();
            foreach (var hddMongo in hardDrivesMongoCollection)
            {
                hardDrivesRepository.Add(
                    new HardDrive
                    {
                        Model = hddMongo.Model,
                        Price = hddMongo.Price,
                        CapacityInGb = hddMongo.CapacityInGb,
                        Manufacturer = hddMongo.Manufacturer
                    });
            }
        }

        public void TransferMemoryDataToSQL(IRepository<Memory> memoriesRepository, IMongoRepository<MemoryMongoModel> memoriesMongoRepository)
        {
            var memoriesMongoCollection = memoriesMongoRepository.GetAll();
            foreach (var memoryMongo in memoriesMongoCollection)
            {
                memoriesRepository.Add(
                    new Memory
                    {
                        CapacityInGb = memoryMongo.CapacityInGb,
                        Price = memoryMongo.Price,
                        Manufacturer = memoryMongo.Manufacturer
                    });
            }
        }

        public void TransferMotherboardDataToSQL(IRepository<Motherboard> motherboardsRepository, IMongoRepository<MotherboardMongoModel> motherboardsMongoRepository)
        {
            var motherboardsMongoCollection = motherboardsMongoRepository.GetAll();
            foreach (var motherboardMongo in motherboardsMongoCollection)
            {
                motherboardsRepository.Add(
                    new Motherboard
                    {
                        Model = motherboardMongo.Model,
                        Price = motherboardMongo.Price,
                        Manufacturer = motherboardMongo.Manufacturer
                    });
            }
        }

        public void TransferProcessorDataToSQL(IRepository<Processor> processorsRepository, IMongoRepository<ProcessorMongoModel> processorsMongoRepository)
        {
            var processorsMongoCollection = processorsMongoRepository.GetAll();
            foreach (var processorMongo in processorsMongoCollection)
            {
                processorsRepository.Add(
                    new Processor
                    {
                        Model = processorMongo.Model,
                        Price = processorMongo.Price,
                        FrequencyInMhz = processorMongo.FrequencyInMhz,
                        Manufacturer = processorMongo.Manufacturer
                    });
            }
        }

        public void TransferVideoCardDataToSQL(IRepository<VideoCard> videoCardsRepository, IMongoRepository<VideoCardMongoModel> videoCardsMongoRepository)
        {
            var videoCardsMongoCollection = videoCardsMongoRepository.GetAll();
            foreach (var videoCardMongo in videoCardsMongoCollection)
            {
                videoCardsRepository.Add(
                    new VideoCard
                    {
                        Model = videoCardMongo.Model,
                        Price = videoCardMongo.Price,
                        Manufacturer = videoCardMongo.Manufacturer
                    });
            }
        }

        public void TransferComputerDataToSQL(IRepository<HardDrive> hardDrivesRepository, IRepository<Memory> memoriesRepository, IRepository<Motherboard> motherboardsRepository, IRepository<Processor> processorsRepository, IRepository<VideoCard> videoCardsRepository, IRepository<ComputerShop> computerShopsRepository, IRepository<Computer> computersRepository, IMongoRepository<ComputerMongoModel> computersMongoRepository)
        {
            var mongoComputers = computersMongoRepository.GetAll();
            foreach (var mongoComputer in mongoComputers)
            {
                var hardDrives = mongoComputer.HardDrives;
                var memory = mongoComputer.Memory;
                var motherboard = mongoComputer.Motherboard;
                var processor = mongoComputer.Processor;
                var videoCard = mongoComputer.Videocard;
                var computerShop = mongoComputer.ComputerShop;

                computersRepository.Add(new Computer
                {
                    Model = mongoComputer.Model,
                    Price = mongoComputer.Price,
                    MemoryId = memoriesRepository.GetAll()
                               .Where(m => m.Manufacturer == memory.Manufacturer && m.Price == memory.Price && m.CapacityInGb == memory.CapacityInGb)
                               .Select(m => m.Id)
                               .First(),
                    MotherboardId = motherboardsRepository.GetAll()
                               .Where(m => m.Model == motherboard.Model && m.Manufacturer == motherboard.Manufacturer && m.Price == motherboard.Price)
                               .Select(m => m.Id)
                               .First(),
                    ProcessorId = processorsRepository.GetAll()
                               .Where(p => p.Model == processor.Model && p.Manufacturer == processor.Manufacturer && p.Price == processor.Price && p.FrequencyInMhz == processor.FrequencyInMhz)
                               .Select(p => p.Id)
                               .First(),
                    VideocardId = videoCardsRepository.GetAll()
                               .Where(v => v.Model == videoCard.Model && v.Manufacturer == videoCard.Manufacturer && v.Price == videoCard.Price)
                               .Select(v => v.Id)
                               .First(),
                    ComputerShopId = computerShopsRepository.GetAll()
                                .Where(sh => sh.Name == computerShop.Name)
                                .Select(sh => sh.Id)
                                .First(),
                    HardDrives = hardDrivesRepository.GetAll()
                                .Where(h => hardDrives.Any(hdds => hdds.Model == h.Model && hdds.Manufacturer == h.Manufacturer && hdds.Price == h.Price))
                                .ToList()
                });
            }
        }

        public void TransferComputerShopDataToSQL(IRepository<ComputerShop> computerShopsRepository, IMongoRepository<ComputerShopMongoModel> computerShopsMongoRepository)
        {
            var computerShopsMongoCollection = computerShopsMongoRepository.GetAll();
            foreach (var computerShopMongo in computerShopsMongoCollection)
            {
                computerShopsRepository.Add(
                    new ComputerShop
                    {
                        Name = computerShopMongo.Name
                    });
            }
        }
    }
}
