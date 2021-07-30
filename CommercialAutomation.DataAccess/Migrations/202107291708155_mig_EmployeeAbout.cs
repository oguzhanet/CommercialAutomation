namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_EmployeeAbout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeeAbout", c => c.String(maxLength: 100));
            AddColumn("dbo.Employees", "EmployeeAddress", c => c.String(maxLength: 50));
            AddColumn("dbo.Employees", "EmployeePhone", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmployeePhone");
            DropColumn("dbo.Employees", "EmployeeAddress");
            DropColumn("dbo.Employees", "EmployeeAbout");
        }
    }
}
