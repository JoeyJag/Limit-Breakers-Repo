namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ReviewId = c.Int(nullable: false),
                        CategoryType = c.String(),
                        ReviewInput = c.String(),
                        GameName = c.String(),
                        Price = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        ReviewDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.Games", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Games", new[] { "ReviewId" });
            DropIndex("dbo.Games", new[] { "CategoryId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Games");
            DropTable("dbo.Categories");
        }
    }
}
