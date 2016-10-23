using System.Collections.Generic;

namespace ComputersFactory.Data.FileSystem.Contracts
{
    public interface IFileSystemService
    {
        void WriteToFile(string filePath, string content);

        IEnumerable<string> ReadFromFile(string filePath);
    }
}
