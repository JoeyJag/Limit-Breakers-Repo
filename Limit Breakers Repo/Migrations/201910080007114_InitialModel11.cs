namespace Limit_Breakers_Repo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReviewGameViewModels", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReviewGameViewModels", "AverageRating", c => c.Int(nullable: false));
        }
    }
}
