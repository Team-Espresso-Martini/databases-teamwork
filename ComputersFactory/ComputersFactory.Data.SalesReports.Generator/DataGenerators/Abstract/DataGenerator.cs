using System;
using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Abstract
{
    public abstract class DataGenerator<TModel> : IDataGenerator<TModel>
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

        public virtual ICollection<TModel> GenerateData(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be larger than zero.");
            }

            return new List<TModel>();
        }
    }
}
