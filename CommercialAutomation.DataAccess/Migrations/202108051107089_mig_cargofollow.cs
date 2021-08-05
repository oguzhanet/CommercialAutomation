namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_cargofollow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoFollows",
                c => new
                    {
                        CargoFollowId = c.Int(nullable: false, identity: true),
                        CargoFollowDescription = c.String(maxLength: 100),
                        CargoFollowCode = c.String(maxLength: 10),
                        CargoFollowDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoFollowId);
            
            AlterColumn("dbo.CargoDetails", "CargoDescription", c => c.String(maxLength: 300));
            AlterColumn("dbo.CargoDetails", "TrackingCode", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CargoDetails", "TrackingCode", c => c.String(maxLength: 15));
            AlterColumn("dbo.CargoDetails", "CargoDescription", c => c.String(maxLength: 100));
            DropTable("dbo.CargoFollows");
        }
    }
}
