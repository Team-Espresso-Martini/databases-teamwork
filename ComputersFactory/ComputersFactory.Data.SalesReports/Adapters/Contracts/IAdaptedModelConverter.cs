using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Converters.Contracts;

namespace ComputersFactory.Data.SalesReports.Adapters.Contracts
{
    public interface IAdaptedModelConverter : IModelConverter
    {
        IList<TModelOut> ConvertToIList<TModelIn, TModelOut>(IEnumerable<TModelIn> inputData)
            where TModelOut : new();
    }
}
