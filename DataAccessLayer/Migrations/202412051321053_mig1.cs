namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutDetails1 = c.String(maxLength: 1000),
                        AboutDetails2 = c.String(maxLength: 1000),
                        AboutImage1 = c.String(maxLength: 500),
                        AboutImage2 = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 50),
                        AuthorSurname = c.String(maxLength: 50),
                        AuthorImage = c.String(maxLength: 500),
                        AuthorMail = c.String(maxLength: 50),
                        AuthorPassword = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(maxLength: 1000),
                        ContentDate = c.DateTime(nullable: false),
                        HeadingId = c.Int(nullable: false),
                        AuthorId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Headings", t => t.HeadingId, cascadeDelete: true)
                .Index(t => t.HeadingId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingId = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 50),
                        HeadingDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryDescription = c.String(maxLength: 500),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Headings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Headings", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Contents", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Headings", new[] { "AuthorId" });
            DropIndex("dbo.Headings", new[] { "CategoryId" });
            DropIndex("dbo.Contents", new[] { "AuthorId" });
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.Headings");
            DropTable("dbo.Contents");
            DropTable("dbo.Authors");
            DropTable("dbo.Abouts");
        }
    }
}
