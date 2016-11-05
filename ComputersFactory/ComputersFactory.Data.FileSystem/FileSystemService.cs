using System;
using System.Collections.Generic;

using ComputersFactory.Data.FileSystem.Contracts;

namespace ComputersFactory.Data.FileSystem
{
    public class FileSystemService : IFileSystemService
    {
        private readonly IFileSystemProvider fileSystemProvider;

        public FileSystemService(IFileSystemProvider fileSystemProvider)
        {
            if (fileSystemProvider == null)
            {
                throw new ArgumentNullException(nameof(fileSystemProvider));
            }

            this.fileSystemProvider = fileSystemProvider;
        }

        public IEnumerable<string> ReadFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var content = this.fileSystemProvider.ReadAllLines(filePath);
            return content;
        }

        public void WriteToFile(string filePath, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            this.fileSystemProvider.WriteAllText(filePath, content);
        }
    }
}
