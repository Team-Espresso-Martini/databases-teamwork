using System.Collections.Generic;

namespace ComputersFactory.Data.FileSystem.Contracts
{
    public interface IFileSystemProvider
    {
        IEnumerable<string> ReadAllLines(string filePath);

        void WriteAllText(string filePath, string text);
    }
}
