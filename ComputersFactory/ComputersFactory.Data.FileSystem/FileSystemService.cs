using System;
using System.Collections.Generic;
using System.IO;

using ComputersFactory.Data.FileSystem.Contracts;

namespace ComputersFactory.Data.FileSystem
{
    public class FileSystemService : IFileSystemService
    {
        public IEnumerable<string> ReadFromFile(string filePath)
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

            var content = File.ReadAllLines(filePath);
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

            var filePathInfo = new FileInfo(filePath);
            var directoryName = filePathInfo.DirectoryName;
            var containingDirectoryExists = Directory.Exists(directoryName);
            if (!containingDirectoryExists)
            {
                throw new DirectoryNotFoundException(filePath);
            }

            File.WriteAllText(filePath, content);
        }
    }
}
