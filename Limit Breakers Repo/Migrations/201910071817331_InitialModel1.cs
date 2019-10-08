namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        GName = c.String(),
                        genre = c.String(),
                        price = c.Double(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "GameID", "dbo.Games");
            DropIndex("dbo.Carts", new[] { "GameID" });
            DropTable("dbo.Carts");
        }
    }
}
