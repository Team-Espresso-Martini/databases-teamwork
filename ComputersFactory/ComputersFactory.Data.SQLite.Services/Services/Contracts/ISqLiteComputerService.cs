using System.Collections.Generic;

using ComputersFactory.Data.Models;

namespace ComputersFactory.Data.SQLite.Services.Services.Contracts
{
    public interface ISqLiteComputerService
    {
        IEnumerable<SqLiteComputer> CreateSqLiteComputers(IEnumerable<Computer> computers);

        IEnumerable<SqLiteComputer> GetAllSqLiteComputers();
    }
}
