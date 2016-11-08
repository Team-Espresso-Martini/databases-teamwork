using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Converters.Contracts
{
    public interface IModelConverter
    {
        IEnumerable<TModelOut> Convert<TModelIn, TModelOut>(IEnumerable<TModelIn> inputData)
            where TModelOut : new();
    }
}
