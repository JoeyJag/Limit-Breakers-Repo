namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "GameID", "dbo.Games");
            DropIndex("dbo.Carts", new[] { "GameID" });
            DropColumn("dbo.Carts", "GameID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "GameID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "GameID");
            AddForeignKey("dbo.Carts", "GameID", "dbo.Games", "GameID", cascadeDelete: true);
        }
    }
}
