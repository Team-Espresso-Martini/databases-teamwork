using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.Converters.Contracts
{
    public interface IModelConverter
    {
        IList<TModelOut> Convert<TModelIn, TModelOut>(IEnumerable<TModelIn> inputData)
            where TModelOut : new();
    }
}
