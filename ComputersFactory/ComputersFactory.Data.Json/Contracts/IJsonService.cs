using System.Collections.Generic;

namespace ComputersFactory.Data.Json.Contracts
{
    public interface IJsonService
    {
        void SaveModelDataToFileSystemAsJson<ModelType>(IEnumerable<ModelType> modelData, string rootDirectoryPath);
    }
}
