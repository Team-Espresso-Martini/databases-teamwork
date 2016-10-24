using System.Collections.Generic;

namespace ComputersFactory.Data.Services.Contracts
{
    public interface IDatabaseWriterService
    {
        IEnumerable<ModelType> ReadDataFromDatabase<ModelType>()
            where ModelType : new();
    }
}
