using System.Collections.Generic;

namespace ComputersFactory.Data.Services.Contracts
{
    public interface IDatabaseWriterService
    {
        void SaveDataToDatabase<ModelType>(IEnumerable<ModelType> data);
    }
}
