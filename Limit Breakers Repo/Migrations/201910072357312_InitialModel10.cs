namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewGameViewModels", "AverageRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewGameViewModels", "AverageRating");
        }
    }
}
