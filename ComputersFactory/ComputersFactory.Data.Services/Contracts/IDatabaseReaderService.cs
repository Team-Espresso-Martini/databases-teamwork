using System.Collections.Generic;

namespace ComputersFactory.Data.Services.Contracts
{
    public interface IDatabaseReaderService
    {
        void SaveDataToDatabase<ModelType>(IEnumerable<ModelType> data);
    }
}
