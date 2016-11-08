namespace ComputersFactory.Data.MySql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MySqlReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(unicode: false),
                        TotalSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MySqlReports");
        }
    }
}
