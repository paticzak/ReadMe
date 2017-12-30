namespace ReadMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopularityToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Popularity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Popularity");
        }
    }
}
