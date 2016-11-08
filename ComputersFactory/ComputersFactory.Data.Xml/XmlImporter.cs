using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ComputersFactory.Data.Models;
using ComputersFactory.Data.Xml.XmlModels;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data.Xml
{
    public static class XmlImporter
    {
        public static void Import()
        {
            // get directory of .xml files whit reflection
            var xmlComputerShop =
                       Directory
                       .GetFiles(Directory.GetCurrentDirectory() + "/XmlFilesForImport/")
                       .Where(file => file.EndsWith(".xml"))
                       .Select(file => File.ReadAllText(file))
                       .FirstOrDefault();

            var stringReader = new StringReader(xmlComputerShop);
            var xmlSerializer = (ComputerShop)new XmlSerializer(typeof(ComputerShop)).Deserialize(stringReader);

            var db = new ComputersFactorySqlDbContext();

            ComputersFactory.Models.ComputerShop compShop = new ComputersFactory.Models.ComputerShop
            {
                Name = xmlSerializer.Name
            };

            foreach (var computer in xmlSerializer.Computer)
            {
                var CurrentHardDrive = new List<HardDrive>();

                foreach (var hardD in computer.Components.HardDrives)
                {
                    var currentHartDrive = new HardDrive
                    {
                        Price = hardD.Price,
                        Manufacturer = hardD.Manufacturer,
                        Model = hardD.Model,
                        CapacityInGb = hardD.Capacity
                    };

                    CurrentHardDrive.Add(currentHartDrive);
                }

                var currentMemory = new Memory
                {
                    Price = computer.Components.Memory.Price,
                    Manufacturer = computer.Components.Memory.Manufacturer,
                    CapacityInGb = computer.Components.Memory.CapacityInGb,
                };

                var currentMotherboard = new Motherboard
                {
                    Price = computer.Components.Motherboard.Price,
                    Manufacturer = computer.Components.Motherboard.Manufacturer,
                    Model = computer.Components.Motherboard.Model
                };

                var currentProcesor = new Processor
                {
                    Price = computer.Components.Processor.Price,
                    Manufacturer = computer.Components.Processor.Manufacturer,
                    Model = computer.Components.Processor.Model,
                    FrequencyInMhz = computer.Components.Processor.FrequencyInMhz
                };

                var currentVideoCard = new VideoCard
                {
                    Price = computer.Components.Processor.Price,
                    Manufacturer = computer.Components.Processor.Manufacturer,
                    Model = computer.Components.Processor.Model
                };

                var currentComputer = new Computer
                {
                    Price = computer.ComputerPrice,
                    Model = computer.Model,
                    Memory = currentMemory,
                    Motherboard = currentMotherboard,
                    Processor = currentProcesor,
                    Videocard = currentVideoCard,
                    HardDrives = CurrentHardDrive
                };

                compShop.Computers.Add(currentComputer);
            }

            try
            {
                db.ComputersShops.Add(compShop);
                db.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
