namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_employeestatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeeStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmployeeStatus");
        }
    }
}
