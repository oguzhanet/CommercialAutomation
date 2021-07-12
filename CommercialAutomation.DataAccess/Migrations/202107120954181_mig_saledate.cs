namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_saledate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleMovements", "Piece", c => c.Int(nullable: false));
            AddColumn("dbo.SaleMovements", "SaleDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SaleMovements", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleMovements", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.SaleMovements", "SaleDate");
            DropColumn("dbo.SaleMovements", "Piece");
        }
    }
}
