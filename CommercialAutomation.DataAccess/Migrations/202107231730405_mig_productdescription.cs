namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_productdescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductDescription", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductDescription");
        }
    }
}
