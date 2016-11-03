using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Adapters.Contracts
{
    public interface IAdaptedModelConverter
    {
        IList<TModelOut> Convert<TModelIn, TModelOut>(IEnumerable<TModelIn> inputData)
            where TModelOut : new();
    }
}
