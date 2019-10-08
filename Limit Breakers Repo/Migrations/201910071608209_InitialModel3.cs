namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Games", "ReviewId", "dbo.Reviews");
            DropIndex("dbo.Games", new[] { "CategoryId" });
            DropIndex("dbo.Games", new[] { "ReviewId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Games");
            DropTable("dbo.Reviews");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.GameID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateIndex("dbo.Games", "ReviewId");
            CreateIndex("dbo.Games", "CategoryId");
            AddForeignKey("dbo.Games", "ReviewId", "dbo.Reviews", "ReviewId", cascadeDelete: true);
            AddForeignKey("dbo.Games", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
