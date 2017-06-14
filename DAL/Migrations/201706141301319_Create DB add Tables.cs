namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDBaddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 100),
                        Password = c.String(maxLength: 16),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        TimePurchase = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.BasketRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        BasketId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.BasketId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BasketId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isbn = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                        Price = c.Double(nullable: false),
                        PublishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishes", t => t.PublishId, cascadeDelete: true)
                .Index(t => t.PublishId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenDate = c.DateTime(nullable: false),
                        CloseDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Books", t => t.BookId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Publishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookQuality = c.Int(nullable: false),
                        ReviewDescription = c.String(maxLength: 500),
                        BookId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_Id, t.Book_Id })
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Book_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.TagBooks",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Book_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Baskets", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.TagBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.TagBooks", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Reviews", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "PublishId", "dbo.Publishes");
            DropForeignKey("dbo.Pictures", "BookId", "dbo.Books");
            DropForeignKey("dbo.OrderRecords", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderRecords", "BookId", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.BasketRecords", "BookId", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BasketRecords", "BasketId", "dbo.Baskets");
            DropIndex("dbo.TagBooks", new[] { "Book_Id" });
            DropIndex("dbo.TagBooks", new[] { "Tag_Id" });
            DropIndex("dbo.CategoryBooks", new[] { "Book_Id" });
            DropIndex("dbo.CategoryBooks", new[] { "Category_Id" });
            DropIndex("dbo.AuthorBooks", new[] { "Book_Id" });
            DropIndex("dbo.AuthorBooks", new[] { "Author_Id" });
            DropIndex("dbo.Reviews", new[] { "CustomerId" });
            DropIndex("dbo.Reviews", new[] { "BookId" });
            DropIndex("dbo.Pictures", new[] { "BookId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderRecords", new[] { "BookId" });
            DropIndex("dbo.OrderRecords", new[] { "OrderId" });
            DropIndex("dbo.Books", new[] { "PublishId" });
            DropIndex("dbo.BasketRecords", new[] { "BookId" });
            DropIndex("dbo.BasketRecords", new[] { "BasketId" });
            DropIndex("dbo.Baskets", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropTable("dbo.TagBooks");
            DropTable("dbo.CategoryBooks");
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.Tags");
            DropTable("dbo.Reviews");
            DropTable("dbo.Publishes");
            DropTable("dbo.Pictures");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRecords");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.BasketRecords");
            DropTable("dbo.Baskets");
            DropTable("dbo.Customers");
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
