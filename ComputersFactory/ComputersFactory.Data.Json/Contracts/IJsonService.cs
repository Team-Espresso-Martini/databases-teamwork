using System.Collections.Generic;

namespace ComputersFactory.Data.Json.Contracts
{
    public interface IJsonService
    {
        void SaveModelDataToFileSystem<ModelType>(IEnumerable<ModelType> modelData, string rootDirectoryPath);
    }
}
