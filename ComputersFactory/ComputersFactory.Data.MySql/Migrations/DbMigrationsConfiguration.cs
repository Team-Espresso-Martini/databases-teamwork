using System.Data.Entity.Migrations;

namespace ComputersFactory.Data.MySql.Migrations
{
    public sealed class MySqlEntityConfiguration : DbMigrationsConfiguration<ComputersFactoryMySqlDbContext>
    {
        public MySqlEntityConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ComputersFactoryMySqlDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
