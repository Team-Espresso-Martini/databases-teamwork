using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.MongoDbWriter.Models;
using ComputersFactory.Data.MongoDbWriter.Models.Components;

using MongoDB.Bson;
using MongoDB.Driver;

namespace ComputersFactory.Data.MongoDbWriter
{
    public static class MongoDbWriter
    {
        private const string dbHost = "mongodb://localhost";
        private const string dbName = "ComputersFactory";

        public static void GenerateData()
        {
            var client = new MongoClient(dbHost);
            var database = client.GetDatabase(dbName);

            GenerateHardDrives(database);
            GenerateMemories(database);
            GenerateMotherboards(database);
            GenerateProcessors(database);
            GenerateVideoCards(database);
            GenerateComputerShops(database);
            GenerateComputers(database);
        }

        private static void GenerateHardDrives(IMongoDatabase database)
        {
            var models = new string[] { "ADATA", "Buffalo Technology", "Freecom", "G-Technology", "Hitachi Global Storage Technologies 2009", "Westen Digital 2011", "HGST", "Hyundai", "IoSafe", "LaCie (acquired by Seagate in 2012)", "LG", "Promise Technology", "Samsung", "Seagate Technology", "Silicon Power", "Sony", "Toshiba", "Transcend Information", "TrekStor", "Verbatim Corporation", "Western Digital" };
            var manufacturers = new string[] { "Seagate Technology", "Maxtor", "Samsung", "Toshiba", "Western Digital", "HGST", "ASUS", "ATTO Technology", "Dell", "HP", "Intel", "LG", "LSI", "PNY", "Promise Technology", "StarTech.com", "Supermicro", "Seagate Technology", "Maxtor", "Samsung", "Toshiba", "Western Digital", "HGST", "ASUS", "ATTO Technology", "Dell", "HP", "Intel", "LG", "LSI", "PNY", "Promise Technology", "StarTech.com", "Supermicro" };
            int hardDrivesCount = models.Length;
            decimal price = 99.9m;

            var hardDrives = new HashSet<BsonDocument>();
            var hardDrive = new HardDriveMongoModel();
            for (int i = 0; i < hardDrivesCount; i++)
            {
                hardDrive = new HardDriveMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[i],
                    Price = price + i,
                    CapacityInGb = i + 1,
                    Manufacturer = manufacturers[i]
                };

                hardDrives.Add(hardDrive.ToBsonDocument());
            }

            var hardDrivesCollection = database.GetCollection<BsonDocument>("HardDrives");
            hardDrivesCollection.InsertMany(hardDrives);
        }

        private static void GenerateMemories(IMongoDatabase database)
        {
            var manufacturers = new string[] { "ADATA", "Apacer", "Asus", "Axiom", "Buffalo Technology", "Chaintech", "Corsair Memory", "Crucial", "Dataram", "Fujitsu", "G.Skill", "GeIL", "HP", "IBM", "Infineon", "Kingston Technology", "Lenovo", "Micron Technology", "Mushkin", "Nanya", "PNY", "Rambus", "Ramtron International", "Rendition", "Renesas Technology", "Samsung Semiconductor", "Sandisk", "SK Hynix", "Sony", "Strontium Technology", "Super Talent", "Toshiba", "Transcend", "Wilk Elektronik" };
            int memoriesCount = manufacturers.Length;
            decimal price = 99.9m;

            var memories = new HashSet<BsonDocument>();
            var memory = new MemoryMongoModel();
            for (int i = 1; i < memoriesCount; i++)
            {
                memory = new MemoryMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Price = price % i + price,
                    CapacityInGb = i + 1,
                    Manufacturer = manufacturers[i]
                };

                memories.Add(memory.ToBsonDocument());
            }

            var memoriesCollection = database.GetCollection<BsonDocument>("Memories");
            memoriesCollection.InsertMany(memories);
        }

        private static void GenerateMotherboards(IMongoDatabase database)
        {
            var models = new string[] { "Lanner Inc(industrial motherboards)", "Leadtek", "LiteOn", "Magic - Pro", "MSI(Micro - Star International)", "PNY Technologies", "Powercolor", "Sapphire Technology", "Shuttle Inc.", "Simmtronics", "Supermicro", "Trenton Technology" };
            var manufacturers = new string[] { "Acer", "ACube Systems", "AMAX Information Technologies", "AOpen", "ASRock", "Asus", "Biostar", "Chassis Plans", "ECS (Elitegroup Computer Systems)", "EVGA Corporation", "First International Computer", "Foxconn", "Gigabyte Technology", "Gumstix", "Intel", "Tyan", "VIA Technologies", "Vigor Gaming", "XFX", "Zotac" };
            int motherboardsCount = models.Length;
            decimal price = 20.4m;

            var motherboards = new HashSet<BsonDocument>();
            var motherboard = new MotherboardMongoModel();
            for (int i = 1; i < motherboardsCount; i++)
            {
                motherboard = new MotherboardMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[i],
                    Price = price * i - price,
                    Manufacturer = manufacturers[i]
                };

                motherboards.Add(motherboard.ToBsonDocument());
            }

            var motherboardsCollection = database.GetCollection<BsonDocument>("Motherboards");
            motherboardsCollection.InsertMany(motherboards);
        }

        private static void GenerateProcessors(IMongoDatabase database)
        {
            var models = new string[] { "3xx - Celeron D", "4xx - Celeron", "5xx - Pentium 4", "6xx - Pentium 4", "8xx - Pentium D and Pentium Extreme Edition", "9xx - Pentium D and Pentium Extreme Edition", "E1xxx - Celeron Dual-Core", "E2xxx - Pentium Dual-Core", "E3x00 - Celeron Dual-Core", "E4xxx - Core 2 Duo", "E5x00 - Pentium Dual-Core", "E6xxx - Core 2 Duo", "E6x00 - Pentium Dual-Core", "E7x00 - Core 2 Duo", "E8xxx - Core 2 Duo", "G6xxx - Pentium Dual-Core", "i3-5xx - Core i3", "i5-6xx - Core i5 (dual-core)", "i5-7xx - Core i5 (quad-core)", "i7-8xx - Core i7", "i7-9xx - Core i7 and Core i7 Extreme Edition", "Q6xxx - Core 2 Quad", "Q8xxx - Core 2 Quad", "Q9xxx - Core 2 Quad", "QX6xxx - Core 2 Extreme", "QX9xxx - Core 2 Extreme", "X6xxx - Core 2 Extreme" };
            var manufacturers = new string[] { "Intel", "AMD", "VIA", "DM & P Electronics", "ZF Micro", "Zet GPL", "RDC Semiconductors", "Nvidia", "ALi", "SiS", "GlobalFoundries", "IBM", "TSMC", "Fujitsu" };
            int processorsCount = models.Length;
            decimal price = 92.07m;

            var processors = new HashSet<BsonDocument>();
            var processor = new ProcessorMongoModel();
            for (int i = 1; i < processorsCount; i++)
            {
                processor = new ProcessorMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[i],
                    Price = price + i,
                    Manufacturer = manufacturers[i % manufacturers.Length],
                    FrequencyInMhz = (int)(i * 2.2)
                };

                processors.Add(processor.ToBsonDocument());
            }

            var processorCollection = database.GetCollection<BsonDocument>("Processors");
            processorCollection.InsertMany(processors);
        }

        private static void GenerateVideoCards(IMongoDatabase database)
        {
            var models = new string[] {
            "GeForce 200 series", "GeForce 256","GeForce 300 series","GeForce 400 series","GeForce 500 series","GeForce 700 series","GeForce 900 series","GeForce FX series","Glaze3D","GoForce","Hercules Graphics Card","Hercules Graphics Card Plus","Hercules InColor Card","Hydra Engine","HyperZ","IBM 8514","IBM Monochrome Display Adapter","INMOS G364 framebuffer","Intel 810","Intel 2700G","Intel GMA","IrisVision","Matrox G200","Matrox G400","Matrox Graphics eXpansion Modules","Matrox Mystique","Matrox Parhelia","Matrox Simple Interface","MicroAngelo","Mini-DVI","Radeon HD 6000 Series","NV1","NV2","NvAGP","Nvidia Quadro","Nvidia Tesla"};
            var manufacturers = new string[] {"Asus","BFG (defunct)","Biostar","Chaintech","Club 3D","Diamond Multimedia","ECS","ELSA Technology","EPoX (defunct)","EVGA Corporation","Foxconn","Gainward","Galax","Gigabyte Technology","HIS","Hercules","inno","Leadtek","Matrox","MSI","Oak Technology (defunct)","PNY","Point of View","PowerColor","S3 Graphics","Sapphire Technology","SPARKLE","XFX","palit","Zotac","3dfx Interactive (defunct)","Asus","BFG (defunct)","Biostar","Chaintech","Club 3D","Diamond Multimedia","ECS","ELSA Technology","EPoX (defunct)","EVGA Corporation","Foxconn","Gainward","Galax","Gigabyte Technology","HIS","Hercules","inno","Leadtek","Matrox","MSI","Club 3D","Diamond Multimedia","ECS","ELSA Technology"
            };
            int videoCardsCount = models.Length;
            decimal price = 66.0m;

            var videoCards = new HashSet<BsonDocument>();
            var videoCard = new VideoCardMongoModel();
            for (int i = 0; i < videoCardsCount; i++)
            {
                videoCard = new VideoCardMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[i],
                    Price = price + i,
                    Manufacturer = manufacturers[i]
                };

                videoCards.Add(videoCard.ToBsonDocument());
            }

            var videoCardCollection = database.GetCollection<BsonDocument>("VideoCards");
            videoCardCollection.InsertMany(videoCards);
        }

        private static void GenerateComputers(IMongoDatabase database)
        {
            var models = new string[] {
            "Aspire", "TravelMate", "Acer Chromebook",  "MacBook", "MacBook Pro", "MacBook Air", "ROG Series", "Asus", "Chromebook", "Hewlett-Packard", "HP Elitebook", "HP Envy", "HP OMEN", "HP Chromebook","Lenovo  ThinkPad", "IdeaPad", "Portege", "Tecra" };
            int computersCount = models.Length;
            decimal price = 1200m;
            var hddsCollection = database.GetCollection<HardDriveMongoModel>("HardDrives").AsQueryable().ToList();
            var memoriesCollection = database.GetCollection<MemoryMongoModel>("Memories").AsQueryable().ToList();
            var motherboardsCollection = database.GetCollection<MotherboardMongoModel>("Motherboards").AsQueryable().ToList();
            var processorsCollection = database.GetCollection<ProcessorMongoModel>("Processors").AsQueryable().ToList();
            var videoCardsCollection = database.GetCollection<VideoCardMongoModel>("VideoCards").AsQueryable().ToList();
            var computerShopsCollection = database.GetCollection<ComputerShopMongoModel>("ComputerShops").AsQueryable().ToList();

            var computers = new HashSet<BsonDocument>();
            var computer = new ComputerMongoModel();
            for (int i = 0; i < computersCount - 1; i++)
            {
                computer = new ComputerMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Model = models[i],
                    Price = price + i,
                    Memory = memoriesCollection[i % memoriesCollection.Count],
                    Motherboard = motherboardsCollection[i % motherboardsCollection.Count],
                    Processor = processorsCollection[i % processorsCollection.Count],
                    Videocard = videoCardsCollection[i % videoCardsCollection.Count],
                    ComputerShop = computerShopsCollection[i % computerShopsCollection.Count],
                    HardDrives = new HashSet<HardDriveMongoModel>() { hddsCollection[i], hddsCollection[i + 1] }
                };

                computers.Add(computer.ToBsonDocument());
            }

            var computersCollection = database.GetCollection<BsonDocument>("Computers");
            computersCollection.InsertMany(computers);
        }

        private static void GenerateComputerShops(IMongoDatabase database)
        {
            var names = new string[] { "ABS Computer Tech Inc.", "Ansys Inc.", "Cable Doctor Co.", "Cimetrix", "Cognitech Corporation", "Fieldglass Inc.", "NetIQ Corp", "Precision IT Group", "Southway Systems Inc.", "Symantec Corporation", "Thoughtworks Inc.", "Xactware Solutions, Inc.", "Cable Doctor Co.", "Cimetrix", "Cognitech Corporation", "Fieldglass Inc.", "NetIQ Corp", "Precision IT Group", "Southway Systems Inc.", "Symantec Corporation", "Thoughtworks Inc." };
            int computerShopsCount = names.Length;

            var computerShops = new HashSet<BsonDocument>();
            var computerShop = new ComputerShopMongoModel();
            for (int i = 0; i < computerShopsCount; i++)
            {
                computerShop = new ComputerShopMongoModel()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = names[i]
                };

                computerShops.Add(computerShop.ToBsonDocument());
            }

            var computerShopsCollection = database.GetCollection<BsonDocument>("ComputerShops");
            computerShopsCollection.InsertMany(computerShops);
        }
    }
}
