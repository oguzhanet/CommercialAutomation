namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_customerimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerImage");
        }
    }
}
