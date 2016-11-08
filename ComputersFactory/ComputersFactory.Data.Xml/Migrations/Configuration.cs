namespace ComputersFactory.Data.Xml.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using ComputersFactory.Models.Components;
    using ComputersFactory.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ComputersFactorySqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ComputersFactory.Data.Xml.ComputersFactorySqlDbContext";
        }

        protected override void Seed(ComputersFactorySqlDbContext context)
        {
            //if (context.ComputersShops.Any())
            //{
            //    return;
            //}

            //context.Database.CreateIfNotExists();

            //ComputerShop shop = new ComputerShop()
            //{
            //    Name = "MyShop"
            //};

            //Computer computer = new Computer()
            //{
            //    Price = 1500.5m,
            //    Model = "The Best",
            //    HardDrives = new HashSet<HardDrive>()
            //    {
            //        new HardDrive()
            //        {
            //            CapacityInGb = 1000,
            //            Manufacturer = "Ivancho",
            //            Model = "Mariq",
            //            Price = 0.65m
            //        },
            //        new HardDrive()
            //        {
            //            CapacityInGb = 500,
            //            Manufacturer = "Samsung",
            //            Model = "ssd",
            //            Price = 23.75m
            //        }
            //    },
            //    Memory = new Memory()
            //    {
            //        CapacityInGb = 512,
            //        Manufacturer = "Dell",
            //        Price = 51.1m
            //    },
            //    Motherboard = new Motherboard()
            //    {
            //        Manufacturer = "Gigabyte",
            //        Model = "Pesho554",
            //        Price = 101.6m
            //    },
            //    Processor = new Processor()
            //    {
            //        FrequencyInMhz = 1000,
            //        Manufacturer = "Intel",
            //        Model = "i7",
            //        Price = 500.4m
            //    },
            //    Videocard = new VideoCard()
            //    {
            //        Manufacturer = "NVidia",
            //        Model = "GTX 1050",
            //        Price = 1000.5m
            //    }
            //};

            //shop.Computers.Add(computer);

            //// factory do not have ComutersShops
            //context.ComputersShops.Add(shop);

            //context.SaveChanges();
        }
    }
}
