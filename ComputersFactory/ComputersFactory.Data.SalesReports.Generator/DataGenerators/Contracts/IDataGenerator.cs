using System;
using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Generator.DataGenerators.Contracts
{
    public interface IDataGenerator<TModel>
    {
        Random RandomNumberProvider { get; }

        ICollection<TModel> GenerateData(int count);
    }
}
