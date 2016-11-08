using ComputersFactory.Data.Contracts;

namespace ComputersFactory.Data.Xml
{
    public class ComputersFactorySqlDbContext : AbstractComputersFactoryDbContext, IComputersFactoryDbContext
    {
        public ComputersFactorySqlDbContext() 
            : base("XmlConnection")
        {
        }
    }
}
