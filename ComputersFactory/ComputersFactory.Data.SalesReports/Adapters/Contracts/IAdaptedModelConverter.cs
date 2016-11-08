using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Adapters.Contracts
{
    public interface IAdaptedModelConverter
    {
        IList<TModelOut> ConvertToIList<TModelIn, TModelOut>(IEnumerable<TModelIn> inputData)
            where TModelOut : new();
    }
}
