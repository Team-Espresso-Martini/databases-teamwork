using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.Generator.Contracts;
using ComputersFactory.Data.MongoDbWriter.Models;
using ComputersFactory.Data.MongoDbWriter.Models.Components;
using ComputersFactory.Data.Repositories.Repositories.Contracts;

using MongoDB.Bson;
using MongoDB.Driver;

namespace ComputersFactory.Data.MongoDbWriter
{
    public class MongoDbWriter
    {
        private const int ComponentsCount = 20;
        private const int ComputersCount = 30;
        private const int MinComponentPrice = 50;
        private const int MaxComponentPrice = 200;
        private const int MinComputerPrice = 700;
        private const int MaxComputerPrice = 4000;
        private const int MinGbCapacity = 300;
        private const int MaxGbCapacity = 800;
        private const int MinFrequencyInMhz = 1000;
        private const int MaxFrequencyInMhz = 4000;

        public void GenerateHardDrives(IMongoRepository<HardDriveMongoModel> hardDrivesRepository, IRandomGenerator generator)
        {
            var models = new string[] { "ADATA", "Buffalo Technology", "Freecom", "G-Technology", "Hitachi Global Storage Technologies 2009", "Westen Digital 2011", "HGST", "Hyundai", "IoSafe", "LaCie (acquired by Seagate in 2012)", "LG", "Promise Technology", "Samsung", "Seagate Technology", "Silicon Power", "Sony", "Toshiba", "Transcend Information", "TrekStor", "Verbatim Corporation", "Western Digital" };
            var manufacturers = new string[] { "Seagate Technology", "Maxtor", "Samsung", "Toshiba", "Western Digital", "HGST", "ASUS", "ATTO Technology", "Dell", "HP", "Intel", "LG", "LSI", "PNY", "Promise Technology", "StarTech.com", "Supermicro", "Seagate Technology", "Maxtor", "Samsung", "Toshiba", "Western Digital", "HGST", "ASUS", "ATTO Technology", "Dell", "HP", "Intel", "LG", "LSI", "PNY", "Promise Technology", "StarTech.com", "Supermicro" };

            var hardDrives = new HashSet<HardDriveMongoModel>();
            var hardDrive = new HardDriveMongoModel();
            for (int i = 0; i < ComponentsCount; i++)
            {
                hardDrive = new HardDriveMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[generator.GetRandomNumber(0, models.Length - 1)],
                    Price = generator.GetRandomNumber(MinComponentPrice, MaxComponentPrice),
                    CapacityInGb = generator.GetRandomNumber(MinGbCapacity, MaxGbCapacity),
                    Manufacturer = manufacturers[generator.GetRandomNumber(0, manufacturers.Length - 1)]
                };

                hardDrives.Add(hardDrive);
            }

            hardDrivesRepository.AddMany(hardDrives);
        }

        public void GenerateMemories(IMongoRepository<MemoryMongoModel> memoriesRepository, IRandomGenerator generator)
        {
            var manufacturers = new string[] { "ADATA", "Apacer", "Asus", "Axiom", "Buffalo Technology", "Chaintech", "Corsair Memory", "Crucial", "Dataram", "Fujitsu", "G.Skill", "GeIL", "HP", "IBM", "Infineon", "Kingston Technology", "Lenovo", "Micron Technology", "Mushkin", "Nanya", "PNY", "Rambus", "Ramtron International", "Rendition", "Renesas Technology", "Samsung Semiconductor", "Sandisk", "SK Hynix", "Sony", "Strontium Technology", "Super Talent", "Toshiba", "Transcend", "Wilk Elektronik" };

            var memories = new HashSet<MemoryMongoModel>();
            var memory = new MemoryMongoModel();
            for (int i = 0; i < ComponentsCount; i++)
            {
                memory = new MemoryMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Price = generator.GetRandomNumber(MinComponentPrice, MaxComponentPrice),
                    CapacityInGb = generator.GetRandomNumber(MinGbCapacity, MaxGbCapacity),
                    Manufacturer = manufacturers[generator.GetRandomNumber(0, manufacturers.Length - 1)]
                };

                memories.Add(memory);
            }

            memoriesRepository.AddMany(memories);
        }

        public void GenerateMotherboards(IMongoRepository<MotherboardMongoModel> motherboardsRepository, IRandomGenerator generator)
        {
            var models = new string[] { "Lanner Inc(industrial motherboards)", "Leadtek", "LiteOn", "Magic - Pro", "MSI(Micro - Star International)", "PNY Technologies", "Powercolor", "Sapphire Technology", "Shuttle Inc.", "Simmtronics", "Supermicro", "Trenton Technology" };
            var manufacturers = new string[] { "Acer", "ACube Systems", "AMAX Information Technologies", "AOpen", "ASRock", "Asus", "Biostar", "Chassis Plans", "ECS (Elitegroup Computer Systems)", "EVGA Corporation", "First International Computer", "Foxconn", "Gigabyte Technology", "Gumstix", "Intel", "Tyan", "VIA Technologies", "Vigor Gaming", "XFX", "Zotac" };

            var motherboards = new HashSet<MotherboardMongoModel>();
            var motherboard = new MotherboardMongoModel();
            for (int i = 0; i < ComponentsCount; i++)
            {
                motherboard = new MotherboardMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[generator.GetRandomNumber(0, models.Length - 1)],
                    Price = generator.GetRandomNumber(MinComponentPrice, MaxComponentPrice),
                    Manufacturer = manufacturers[generator.GetRandomNumber(0, manufacturers.Length - 1)]
                };

                motherboards.Add(motherboard);
            }

            motherboardsRepository.AddMany(motherboards);
        }

        public void GenerateProcessors(IMongoRepository<ProcessorMongoModel> processorsRepository, IRandomGenerator generator)
        {
            var models = new string[] { "3xx - Celeron D", "4xx - Celeron", "5xx - Pentium 4", "6xx - Pentium 4", "8xx - Pentium D and Pentium Extreme Edition", "9xx - Pentium D and Pentium Extreme Edition", "E1xxx - Celeron Dual-Core", "E2xxx - Pentium Dual-Core", "E3x00 - Celeron Dual-Core", "E4xxx - Core 2 Duo", "E5x00 - Pentium Dual-Core", "E6xxx - Core 2 Duo", "E6x00 - Pentium Dual-Core", "E7x00 - Core 2 Duo", "E8xxx - Core 2 Duo", "G6xxx - Pentium Dual-Core", "i3-5xx - Core i3", "i5-6xx - Core i5 (dual-core)", "i5-7xx - Core i5 (quad-core)", "i7-8xx - Core i7", "i7-9xx - Core i7 and Core i7 Extreme Edition", "Q6xxx - Core 2 Quad", "Q8xxx - Core 2 Quad", "Q9xxx - Core 2 Quad", "QX6xxx - Core 2 Extreme", "QX9xxx - Core 2 Extreme", "X6xxx - Core 2 Extreme" };
            var manufacturers = new string[] { "Intel", "AMD", "VIA", "DM & P Electronics", "ZF Micro", "Zet GPL", "RDC Semiconductors", "Nvidia", "ALi", "SiS", "GlobalFoundries", "IBM", "TSMC", "Fujitsu" };

            var processors = new HashSet<ProcessorMongoModel>();
            var processor = new ProcessorMongoModel();
            for (int i = 0; i < ComponentsCount; i++)
            {
                processor = new ProcessorMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[generator.GetRandomNumber(0, models.Length - 1)],
                    Price = generator.GetRandomNumber(MinComponentPrice, MaxComponentPrice),
                    Manufacturer = manufacturers[generator.GetRandomNumber(0, manufacturers.Length - 1)],
                    FrequencyInMhz = generator.GetRandomNumber(MinFrequencyInMhz, MaxFrequencyInMhz)
                };

                processors.Add(processor);
            }

            processorsRepository.AddMany(processors);
        }

        public void GenerateVideoCards(IMongoRepository<VideoCardMongoModel> videoCardsRepository, IRandomGenerator generator)
        {
            var models = new string[] {
            "GeForce 200 series", "GeForce 256","GeForce 300 series","GeForce 400 series","GeForce 500 series","GeForce 700 series","GeForce 900 series","GeForce FX series","Glaze3D","GoForce","Hercules Graphics Card","Hercules Graphics Card Plus","Hercules InColor Card","Hydra Engine","HyperZ","IBM 8514","IBM Monochrome Display Adapter","INMOS G364 framebuffer","Intel 810","Intel 2700G","Intel GMA","IrisVision","Matrox G200","Matrox G400","Matrox Graphics eXpansion Modules","Matrox Mystique","Matrox Parhelia","Matrox Simple Interface","MicroAngelo","Mini-DVI","Radeon HD 6000 Series","NV1","NV2","NvAGP","Nvidia Quadro","Nvidia Tesla"};
            var manufacturers = new string[] {"Asus","BFG (defunct)","Biostar","Chaintech","Club 3D","Diamond Multimedia","ECS","ELSA Technology","EPoX (defunct)","EVGA Corporation","Foxconn","Gainward","Galax","Gigabyte Technology","HIS","Hercules","inno","Leadtek","Matrox","MSI","Oak Technology (defunct)","PNY","Point of View","PowerColor","S3 Graphics","Sapphire Technology","SPARKLE","XFX","palit","Zotac","3dfx Interactive (defunct)","Asus","BFG (defunct)","Biostar","Chaintech","Club 3D","Diamond Multimedia","ECS","ELSA Technology","EPoX (defunct)","EVGA Corporation","Foxconn","Gainward","Galax","Gigabyte Technology","HIS","Hercules","inno","Leadtek","Matrox","MSI","Club 3D","Diamond Multimedia","ECS","ELSA Technology"
            };

            var videoCards = new HashSet<VideoCardMongoModel>();
            var videoCard = new VideoCardMongoModel();
            for (int i = 0; i < ComponentsCount; i++)
            {
                videoCard = new VideoCardMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[generator.GetRandomNumber(0, models.Length - 1)],
                    Price = generator.GetRandomNumber(MinComponentPrice, MaxComponentPrice),
                    Manufacturer = manufacturers[generator.GetRandomNumber(0, manufacturers.Length - 1)]
                };

                videoCards.Add(videoCard);
            }

            videoCardsRepository.AddMany(videoCards);
        }

        public void GenerateComputers(IMongoRepository<HardDriveMongoModel> hardDrivesRepository, IMongoRepository<MemoryMongoModel> memoriesRepository, IMongoRepository<MotherboardMongoModel> motherboardsRepository, IMongoRepository<ProcessorMongoModel> processorsRepository, IMongoRepository<VideoCardMongoModel> videoCardsRepository, IMongoRepository<ComputerShopMongoModel> computerShopsRepository, IMongoRepository<ComputerMongoModel> computersRepository, IRandomGenerator generator)
        {
            var models = new string[] { "Aspire", "TravelMate", "Acer Chromebook", "MacBook", "MacBook Pro", "MacBook Air", "ROG Series", "Asus", "Chromebook", "Hewlett-Packard", "HP Elitebook", "HP Envy", "HP OMEN", "HP Chromebook", "Lenovo  ThinkPad", "IdeaPad", "Portege", "Tecra" };

            var hardDrivesCollection = hardDrivesRepository.GetAll().ToList();
            var memoriesCollection = memoriesRepository.GetAll().ToList();
            var motherboardsCollection = motherboardsRepository.GetAll().ToList();
            var processorsCollection = processorsRepository.GetAll().ToList();
            var videoCardsCollection = videoCardsRepository.GetAll().ToList();
            var computerShopsCollection = computerShopsRepository.GetAll().ToList();

            var computers = new HashSet<ComputerMongoModel>();
            var computer = new ComputerMongoModel();
            for (int i = 0; i < ComputersCount; i++)
            {
                computer = new ComputerMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[generator.GetRandomNumber(0, models.Length - 1)],
                    Price = generator.GetRandomNumber(MinComputerPrice, MaxComputerPrice),
                    Memory = memoriesCollection[generator.GetRandomNumber(0, memoriesCollection.Count - 1)],
                    Motherboard = motherboardsCollection[generator.GetRandomNumber(0, motherboardsCollection.Count - 1)],
                    Processor = processorsCollection[generator.GetRandomNumber(0, processorsCollection.Count - 1)],
                    Videocard = videoCardsCollection[generator.GetRandomNumber(0, videoCardsCollection.Count - 1)],
                    ComputerShop = computerShopsCollection[generator.GetRandomNumber(0, computerShopsCollection.Count - 1)],
                    HardDrives = new HashSet<HardDriveMongoModel>() {
                        hardDrivesCollection[generator.GetRandomNumber(0,hardDrivesCollection.Count-1)],
                        hardDrivesCollection[generator.GetRandomNumber(0,hardDrivesCollection.Count-1)]
                    }
                };

                computers.Add(computer);
            }

            computersRepository.AddMany(computers);
        }

        public void GenerateComputerShops(IMongoRepository<ComputerShopMongoModel> computerShopsRepository, IRandomGenerator generator)
        {
            var names = new string[] { "ABS Computer Tech Inc.", "Ansys Inc.", "Cable Doctor Co.", "Cimetrix", "Cognitech Corporation", "Fieldglass Inc.", "NetIQ Corp", "Precision IT Group", "Southway Systems Inc.", "Symantec Corporation", "Thoughtworks Inc.", "Xactware Solutions, Inc.", "Cable Doctor Co.", "Cimetrix", "Cognitech Corporation", "Fieldglass Inc.", "NetIQ Corp", "Precision IT Group", "Southway Systems Inc.", "Symantec Corporation", "Thoughtworks Inc." };

            var computerShops = new HashSet<ComputerShopMongoModel>();
            var computerShop = new ComputerShopMongoModel();
            for (int i = 0; i < ComponentsCount; i++)
            {
                computerShop = new ComputerShopMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = names[generator.GetRandomNumber(0, names.Length - 1)]
                };

                computerShops.Add(computerShop);
            }

            computerShopsRepository.AddMany(computerShops);
        }
    }
}
