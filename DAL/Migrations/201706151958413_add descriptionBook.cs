namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddescriptionBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Description", c => c.String(maxLength: 600));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Description");
        }
    }
}
