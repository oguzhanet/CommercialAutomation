﻿namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerRole");
        }
    }
}