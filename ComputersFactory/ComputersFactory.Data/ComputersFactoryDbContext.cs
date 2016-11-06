using ComputersFactory.Data.Contracts;

namespace ComputersFactory.Data
{
    public class ComputersFactoryDbContext : AbstractComputersFactoryDbContext
    {
        public ComputersFactoryDbContext()
            : base("ComputersFactoryConnection")
        {
        }
    }
}
