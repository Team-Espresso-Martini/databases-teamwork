namespace ComputersFactory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sales : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Computers", "SalesReport_Id", "dbo.SalesReports");
            DropIndex("dbo.Computers", new[] { "SalesReport_Id" });
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComputerId = c.Int(nullable: false),
                        SalesReport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Computers", t => t.ComputerId, cascadeDelete: true)
                .ForeignKey("dbo.SalesReports", t => t.SalesReport_Id)
                .Index(t => t.ComputerId)
                .Index(t => t.SalesReport_Id);
            
            AddColumn("dbo.SalesReports", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Computers", "SalesReport_Id");
            DropColumn("dbo.SalesReports", "Sales");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesReports", "Sales", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Computers", "SalesReport_Id", c => c.Int());
            DropForeignKey("dbo.Sales", "SalesReport_Id", "dbo.SalesReports");
            DropForeignKey("dbo.Sales", "ComputerId", "dbo.Computers");
            DropIndex("dbo.Sales", new[] { "SalesReport_Id" });
            DropIndex("dbo.Sales", new[] { "ComputerId" });
            DropColumn("dbo.SalesReports", "TotalAmount");
            DropTable("dbo.Sales");
            CreateIndex("dbo.Computers", "SalesReport_Id");
            AddForeignKey("dbo.Computers", "SalesReport_Id", "dbo.SalesReports", "Id");
        }
    }
}
