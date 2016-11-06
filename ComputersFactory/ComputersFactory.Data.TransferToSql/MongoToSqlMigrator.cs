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

        public void TransferComputerDataToSQL(IRepository<Computer> computersRepository, IMongoRepository<ComputerMongoModel> computersMongoRepository)
        {
            var computersMongoCollection = computersMongoRepository.GetAll();
            foreach (var computerMongo in computersMongoCollection)
            {
                computersRepository.Add(
                    new Computer
                    {
                        Model = computerMongo.Model,
                        Price = computerMongo.Price,
                        Memory = new Memory
                        {
                            Manufacturer = computerMongo.Memory.Manufacturer,
                            Price = computerMongo.Memory.Price,
                            CapacityInGb = computerMongo.Memory.CapacityInGb
                        },
                        Motherboard = new Motherboard
                        {
                            Manufacturer = computerMongo.Motherboard.Manufacturer,
                            Model = computerMongo.Motherboard.Model,
                            Price = computerMongo.Motherboard.Price
                        },
                        Processor = new Processor
                        {
                            Model = computerMongo.Processor.Model,
                            Manufacturer = computerMongo.Processor.Manufacturer,
                            Price = computerMongo.Processor.Price,
                            FrequencyInMhz = computerMongo.Processor.FrequencyInMhz
                        },
                        Videocard = new VideoCard
                        {
                            Model = computerMongo.Videocard.Model,
                            Manufacturer = computerMongo.Videocard.Manufacturer,
                            Price = computerMongo.Videocard.Price
                        },
                        ComputerShop = new ComputerShop
                        {
                            Name = computerMongo.ComputerShop.Name
                        }
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
