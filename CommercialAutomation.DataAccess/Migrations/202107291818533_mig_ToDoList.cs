namespace CommercialAutomation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ToDoList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        ToDoListId = c.Int(nullable: false, identity: true),
                        ToDoListHeading = c.String(maxLength: 200),
                        ToDoListDate = c.DateTime(nullable: false),
                        ToDoListStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ToDoListId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDoLists");
        }
    }
}
