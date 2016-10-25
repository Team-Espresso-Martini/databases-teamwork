using ComputersFactory.Data.Repositories.Repositories.Contracts;

namespace ComputersFactory.Data.Repositories.UnitsOfWork.Contracts
{
    public interface IUnitOfWork
    {
        IComputersRepository Computers { get; }
    }
}
