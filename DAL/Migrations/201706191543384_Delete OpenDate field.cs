namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOpenDatefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ReviewDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Baskets", "TimePurchase");
            DropColumn("dbo.Orders", "OpenDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OpenDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Baskets", "TimePurchase", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reviews", "ReviewDate");
        }
    }
}
