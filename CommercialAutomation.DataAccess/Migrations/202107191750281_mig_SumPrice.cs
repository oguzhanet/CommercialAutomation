namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_SumPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "SumPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "SumPrice");
        }
    }
}
