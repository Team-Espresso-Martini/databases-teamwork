using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using ComputersFactory.Data.Migrations;
using ComputersFactory.Data.Repositories.UnitsOfWork;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;
using ComputersFactory.Data.Models;

namespace ComputersFactory.Data.Xml
{
    public class XmlReports
    {
        private const string Url = "../../XmlReports/ComputerShop.xml";
        private const string FormatDecimal = "{0:0.00}";

        static void Main()
        {
            Configuration configuration = new Configuration();
            configuration.ContextType = typeof(ComputersFactorySqlDbContext);
            var migrator = new DbMigrator(configuration);

            //This will get the SQL script which will update the DB and write it to debug
            var scriptor = new MigratorScriptingDecorator(migrator);
            string script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null).ToString();
            Debug.Write(script);

            //This will run the migration update script and will run Seed() method
            migrator.Update();


            using (var context = new ComputersFactorySqlDbContext())
            {
                ComputersFactoryUnitOfWork factory = new ComputersFactoryUnitOfWork(context);

                Computer computer = factory.Computers.GetAll().FirstOrDefault(comp => comp.Price > 100);

                GenerateComputerShopXmlReport(computer, Url);
            }

            Console.WriteLine("---***---  DATABASE DONE  ---***---");

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
