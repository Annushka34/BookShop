namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRankToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Rank", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Rank");
        }
    }
}
