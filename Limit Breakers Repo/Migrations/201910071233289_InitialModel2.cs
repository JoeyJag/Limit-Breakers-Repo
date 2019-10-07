namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameDetails",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        Description = c.String(),
                        ImageLocation = c.String(),
                        GameLocation = c.String(),
                    })
                .PrimaryKey(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameDetails");
        }
    }
}
