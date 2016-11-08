using System.Data.Entity.Migrations;

namespace ComputersFactory.Data.Migrations
{

    public sealed class Configuration : DbMigrationsConfiguration<ComputersFactoryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "ComputersFactory.Data.ComputersFactoryDbContext";
        }

        protected override void Seed(ComputersFactoryDbContext context)
        {

        }
    }
}
