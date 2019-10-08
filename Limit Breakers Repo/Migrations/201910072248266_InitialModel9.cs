namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewGameViewModels",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReviewOfGame = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID);
            
            AlterColumn("dbo.Reviews", "ReviewOfGame", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "ReviewOfGame", c => c.String());
            DropTable("dbo.ReviewGameViewModels");
        }
    }
}
