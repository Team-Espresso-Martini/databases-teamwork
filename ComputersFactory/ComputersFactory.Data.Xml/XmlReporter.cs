using System.Linq;
using System.Xml.Linq;
using ComputersFactory.Data.Models;
using ComputersFactory.Data.Repositories.UnitsOfWork;
using ComputersFactory.Models.Components;

namespace ComputersFactory.Data.Xml
{
    public static class XmlReporter
    {
        private const string Url = "../../XmlReports/ComputerShop.xml";
        private const string FormatDecimal = "{0:0.00}";

        public static void MakeReport()
        {

            using (var context = new ComputersFactorySqlDbContext())
            {
                ComputersFactoryUnitOfWork factory = new ComputersFactoryUnitOfWork(context);

                Computer computer = factory.Computers.GetAll().FirstOrDefault(comp => comp.Price > 100);

                GenerateComputerShopXmlReport(computer, Url);
            }
        }

        public static void GenerateComputerShopXmlReport(Computer computer, string url)
        {
            XElement hardDrivesInCurrentComp = new XElement("HardDrives");
            foreach (HardDrive hardDrive in computer.HardDrives)
            {
                XElement currentHardDrive = new XElement("HardDrive",
                    new XElement("Capacity", hardDrive.CapacityInGb),
                    new XElement("Manufacturer", hardDrive.Manufacturer),
                    new XElement("Model", hardDrive.Model),
                    new XElement("Price", hardDrive.Price));

                hardDrivesInCurrentComp.Add(currentHardDrive);
            }

            XDocument xmlDocument = new XDocument();
            xmlDocument.Add(new XElement("ComputerShop",
                    new XElement("Computer",
                        new XAttribute("ComuterID", computer.Id),
                            new XElement("ComputerPrice", string.Format(FormatDecimal, computer.Price)),
                            new XElement("Components",
                                new XElement("Motherboard",
                                    new XElement("Price", string.Format(FormatDecimal, computer.Motherboard.Price)),
                                    new XElement("Manufacturer", computer.Motherboard.Manufacturer),
                                    new XElement("Model", computer.Motherboard.Model)),
                                new XElement("Memory",
                                    new XElement("Price", string.Format(FormatDecimal, computer.Memory.Price)),
                                    new XElement("Manufacturer", computer.Memory.Manufacturer),
                                    new XElement("CapacityInGb", computer.Memory.CapacityInGb)),
                                new XElement("Processor",
                                    new XElement("Price", string.Format(FormatDecimal, computer.Processor.Price)),
                                    new XElement("Manufacturer", computer.Processor.Manufacturer),
                                    new XElement("Model", computer.Processor.Model),
                                    new XElement("FrequencyInMhz", computer.Processor.FrequencyInMhz)),
                                new XElement("VideoCard",
                                    new XElement("Price", string.Format(FormatDecimal, computer.Videocard.Price)),
                                    new XElement("Manufacturer", computer.Videocard.Manufacturer),
                                    new XElement("Model", computer.Videocard.Model))
            ))));

            var components = xmlDocument.Root.Elements("Computer")
                 .Select(comp => comp.Element("Components")).ToList();
            components[0].Add(hardDrivesInCurrentComp);

            xmlDocument.Save(url);
        }
    }
}


