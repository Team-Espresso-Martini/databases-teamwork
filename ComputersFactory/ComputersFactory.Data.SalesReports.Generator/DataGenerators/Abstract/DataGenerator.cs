using System;
using System.Collections.Generic;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Abstract
{
    public class DataGenerator<TModel> : IDataGenerator
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

        public virtual ICollection<TModel> GenerateData(int count, IList<Computer> availableComputers)
        {
            if (availableComputers == null)
            {
                throw new ArgumentNullException(nameof(availableComputers));
            }

            if (availableComputers.Count == 0)
            {
                throw new ArgumentException("Available computers collection is empty.", nameof(availableComputers));
            }

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be larger than zero.");
            }

            return new List<TModel>();
        }
    }
}
