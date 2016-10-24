using System.Collections.Generic;

namespace ComputersFactory.Data.Services.Contracts
{
    public interface IDatabaseService : IDatabaseReaderService, IDatabaseWriterService
    {
    }
}
