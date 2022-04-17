namespace Chitalka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParamsMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bookInside = c.String(),
                        bookName = c.String(),
                        descriprionBook = c.String(),
                        img = c.String(),
                        categoryName = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        category_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.category_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                        description = c.String(),
                        catName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        usrName = c.String(),
                        pswrd = c.String(),
                        ifAdmin = c.Boolean(nullable: false),
                        mail = c.String(),
                        ico = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "category_id", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "category_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
        }
    }
}
