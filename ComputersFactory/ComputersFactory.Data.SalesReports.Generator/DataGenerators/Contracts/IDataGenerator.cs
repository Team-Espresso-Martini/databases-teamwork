using System;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts
{
    public interface IDataGenerator
    {
        Random RandomNumberProvider { get; }
    }
}
