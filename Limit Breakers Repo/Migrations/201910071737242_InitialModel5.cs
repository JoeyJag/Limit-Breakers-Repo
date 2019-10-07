namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "GameDetails_GameID", "dbo.GameDetails");
            DropIndex("dbo.Reviews", new[] { "GameDetails_GameID" });
            RenameColumn(table: "dbo.Reviews", name: "GameDetails_GameID", newName: "GameID");
            AlterColumn("dbo.Reviews", "GameID", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "GameID");
            AddForeignKey("dbo.Reviews", "GameID", "dbo.GameDetails", "GameID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "GameID", "dbo.GameDetails");
            DropIndex("dbo.Reviews", new[] { "GameID" });
            AlterColumn("dbo.Reviews", "GameID", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "GameID", newName: "GameDetails_GameID");
            CreateIndex("dbo.Reviews", "GameDetails_GameID");
            AddForeignKey("dbo.Reviews", "GameDetails_GameID", "dbo.GameDetails", "GameID");
        }
    }
}
