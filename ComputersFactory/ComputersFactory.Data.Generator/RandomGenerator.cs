using ComputersFactory.Data.Generator.Contracts;
using System;

namespace ComputersFactory.Data.Generator
{
    public class RandomGenerator : IRandomGenerator
    {
        private static RandomGenerator instance;
        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Create
        {
            get
            {
                return instance ?? (instance = new RandomGenerator());
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }
    }
}
