using System;

using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Abstract
{
    public class DataGenerator : IDataGenerator
    {
        private readonly Random randomNumberProvider;

        public DataGenerator()
        {
            this.randomNumberProvider = new Random();
        }

        public Random RandomNumberProvider
        {
            get
            {
                return this.randomNumberProvider;
            }
        }
    }
}
