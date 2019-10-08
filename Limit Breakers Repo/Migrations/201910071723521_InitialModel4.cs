namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewOfGame = c.String(),
                        Rating = c.Int(nullable: false),
                        GameDetails_GameID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.GameDetails", t => t.GameDetails_GameID)
                .Index(t => t.GameDetails_GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "GameDetails_GameID", "dbo.GameDetails");
            DropIndex("dbo.Reviews", new[] { "GameDetails_GameID" });
            DropTable("dbo.Reviews");
        }
    }
}
