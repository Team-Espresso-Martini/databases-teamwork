using System;
using System.Collections.Generic;

using ComputersFactory.Data.SalesReports.Adapters.Contracts;
using ComputersFactory.Data.SalesReports.Converters.Contracts;

namespace ComputersFactory.Data.SalesReports.Adapters
{
    public class AdaptedModelConverter : IAdaptedModelConverter, IModelConverter
    {
        private readonly IModelConverter modelConverter;

        public AdaptedModelConverter(IModelConverter modelConverter)
        {
            if (modelConverter == null)
            {
                throw new ArgumentNullException(nameof(modelConverter));
            }
            this.modelConverter = modelConverter;
        }

        public IEnumerable<TModelOut> Convert<TModelIn, TModelOut>(IEnumerable<TModelIn> inputData) where TModelOut : new()
        {
            return this.modelConverter.Convert<TModelIn, TModelOut>(inputData);
        }

        public IList<TModelOut> ConvertToIList<TModelIn, TModelOut>(IEnumerable<TModelIn> inputData) where TModelOut : new()
        {
            var convertedData = this.modelConverter.Convert<TModelIn, TModelOut>(inputData);

            var adaptedList = new List<TModelOut>(convertedData);
            return adaptedList;
        }
    }
}
