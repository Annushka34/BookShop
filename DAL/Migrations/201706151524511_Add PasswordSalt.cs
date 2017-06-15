namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPasswordSalt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordSalt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PasswordSalt");
        }
    }
}
