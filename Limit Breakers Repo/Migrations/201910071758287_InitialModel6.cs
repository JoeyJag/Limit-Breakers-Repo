namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "GameID", "dbo.GameDetails");
            DropIndex("dbo.Reviews", new[] { "GameID" });
            RenameColumn(table: "dbo.Reviews", name: "GameID", newName: "GameDetails_GameID");
            AddColumn("dbo.Reviews", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "GameDetails_GameID", c => c.Int());
            CreateIndex("dbo.Reviews", "GameDetails_GameID");
            AddForeignKey("dbo.Reviews", "GameDetails_GameID", "dbo.GameDetails", "GameID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "GameDetails_GameID", "dbo.GameDetails");
            DropIndex("dbo.Reviews", new[] { "GameDetails_GameID" });
            AlterColumn("dbo.Reviews", "GameDetails_GameID", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "Name");
            RenameColumn(table: "dbo.Reviews", name: "GameDetails_GameID", newName: "GameID");
            CreateIndex("dbo.Reviews", "GameID");
            AddForeignKey("dbo.Reviews", "GameID", "dbo.GameDetails", "GameID", cascadeDelete: true);
        }
    }
}
