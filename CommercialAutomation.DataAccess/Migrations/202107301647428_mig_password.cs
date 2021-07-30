namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_password : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerPassword", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerPassword");
        }
    }
}
