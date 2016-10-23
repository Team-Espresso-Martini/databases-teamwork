using System;
using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.FileSystem.Contracts;
using ComputersFactory.Data.Json.Contracts;

namespace ComputersFactory.Data.Json
{
    public class JsonService : IJsonService
    {
        private readonly IJsonProvider jsonProvider;
        private readonly IFileSystemService fileSystemService;

        public JsonService(IJsonProvider jsonProvider, IFileSystemService fileSystemService)
        {
            if (jsonProvider == null)
            {
                throw new ArgumentNullException(nameof(jsonProvider));
            }

            if (fileSystemService == null)
            {
                throw new ArgumentNullException(nameof(fileSystemService));
            }

            this.jsonProvider = jsonProvider;
            this.fileSystemService = fileSystemService;
        }

        public void SaveModelDataToFileSystem<ModelType>(IEnumerable<ModelType> modelData, string rootDirectoryPath)
        {
            if (modelData == null)
            {
                throw new ArgumentNullException(nameof(modelData));
            }

            if (string.IsNullOrEmpty(rootDirectoryPath))
            {
                throw new ArgumentNullException(nameof(rootDirectoryPath));
            }

            var dataCollection = modelData.Where(item => item != null).ToList();
            foreach (var item in dataCollection)
            {
                var json = this.jsonProvider.SerializeObject(item);
                this.fileSystemService.WriteToFile(rootDirectoryPath, json);
            }

            throw new NotImplementedException();
        }
    }
}
