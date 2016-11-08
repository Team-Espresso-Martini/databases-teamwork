using System;
using System.Collections.Generic;
using System.IO;

using ComputersFactory.Data.FileSystem.Contracts;

namespace ComputersFactory.Data.FileSystem.FileSystemProviders
{
    public class ResolveMissingPathFileSystemProvider : IFileSystemProvider
    {
        private readonly IFileSystemProvider fileSystemProviderComponent;

        public ResolveMissingPathFileSystemProvider(IFileSystemProvider fileSystemProviderComponent)
        {
            if (fileSystemProviderComponent == null)
            {
                throw new ArgumentNullException(nameof(fileSystemProviderComponent));
            }

            this.fileSystemProviderComponent = fileSystemProviderComponent;
        }

        public IEnumerable<string> ReadAllLines(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var fileExists = File.Exists(filePath);
            if (!fileExists)
            {
                throw new FileNotFoundException(filePath);
            }

            var content = this.fileSystemProviderComponent.ReadAllLines(filePath);
            return content;
        }

        public void WriteAllText(string filePath, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var filePathInfo = new FileInfo(filePath);
            var directoryPath = filePathInfo.DirectoryName;

            var containingDirectoryExists = Directory.Exists(directoryPath);
            if (!containingDirectoryExists)
            {
                Directory.CreateDirectory(directoryPath);
            }

            this.fileSystemProviderComponent.WriteAllText(filePath, text);
        }
    }
}
