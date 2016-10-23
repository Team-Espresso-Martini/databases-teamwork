using System.Collections.Generic;
using System.IO;

using ComputersFactory.Data.FileSystem.Contracts;

namespace ComputersFactory.Data.FileSystem
{
    public class FileSystemService : IFileSystemService
    {
        public IEnumerable<string> ReadFromFile(string filePath)
        {
            var content = File.ReadAllLines(filePath);
            return content;
        }

        public void WriteToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}
