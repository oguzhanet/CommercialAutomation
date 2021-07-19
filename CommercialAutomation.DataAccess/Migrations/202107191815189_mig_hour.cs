namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_hour : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "Hour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "Hour", c => c.DateTime(nullable: false));
        }
    }
}
