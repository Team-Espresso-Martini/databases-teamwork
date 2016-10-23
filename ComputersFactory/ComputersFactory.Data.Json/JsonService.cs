using System;
using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.FileSystem.Contracts;
using ComputersFactory.Data.Json.Contracts;

namespace ComputersFactory.Data.Json
{
    public class JsonService : IJsonService
    {
        private const string TargetDirectoryTemplate = "{0}\\{1}s\\";
        private const string TargetFileNameTemplate = "{0}{1}.json";

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

            var modelTypeInfo = typeof(ModelType);
            var modelTypeName = modelTypeInfo.Name;
            var targetDirectory = this.ResolveDirectoryNameForModel(rootDirectoryPath, modelTypeName);

            var dataCollection = modelData.Where(item => item != null).ToList();
            foreach (var item in dataCollection)
            {
                var fileNameWithoutExtension = this.ResolveFileNameWithoutExtensionFromModelIdPropertyValue<ModelType>(item);
                var fullFilePath = this.ResolveFullPathToTargetFileName(targetDirectory, fileNameWithoutExtension);

                var json = this.jsonProvider.SerializeObject(item);
                this.fileSystemService.WriteToFile(rootDirectoryPath, json);
            }

            throw new NotImplementedException();
        }

        private string ResolveDirectoryNameForModel(string rootDirectoryPath, string modelName)
        {
            var targetDirectory = string.Format(JsonService.TargetDirectoryTemplate, rootDirectoryPath, modelName);
            return targetDirectory;
        }

        private string ResolveFullPathToTargetFileName(string targetDirectory, string fileName)
        {
            var fullPath = string.Format(JsonService.TargetFileNameTemplate, targetDirectory, fileName);
            return fullPath;
        }

        private string ResolveFileNameWithoutExtensionFromModelIdPropertyValue<ModelType>(ModelType item)
        {
            var itemTypeInfo = item.GetType();
            var itemTypeName = itemTypeInfo.Name;
            var itemTypeProperties = itemTypeInfo.GetProperties();

            var idProperty = itemTypeProperties
                .Where(prop => prop.Name == "Id" || prop.Name == itemTypeName + "Id")
                .FirstOrDefault();

            var idPropertyExists = idProperty != null;
            if (!idPropertyExists)
            {
                throw new ArgumentException("propery Id does not exist.");
            }

            var fileNameWithoutExtension = idProperty.GetValue(item).ToString();

            return fileNameWithoutExtension;
        }
    }
}
