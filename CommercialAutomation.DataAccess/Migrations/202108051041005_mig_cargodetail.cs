namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_cargodetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailId = c.Int(nullable: false, identity: true),
                        CargoDescription = c.String(maxLength: 100),
                        TrackingCode = c.String(maxLength: 15),
                        CargoDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CargoDetails", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CargoDetails", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CargoDetails", new[] { "CustomerId" });
            DropIndex("dbo.CargoDetails", new[] { "EmployeeId" });
            DropTable("dbo.CargoDetails");
        }
    }
}
