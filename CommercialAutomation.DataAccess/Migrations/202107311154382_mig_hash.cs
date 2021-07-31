namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_hash : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Customers", "CustomerPassword", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerPassword", c => c.String(maxLength: 15));
            AlterColumn("dbo.Admins", "Password", c => c.String(maxLength: 16));
        }
    }
}
