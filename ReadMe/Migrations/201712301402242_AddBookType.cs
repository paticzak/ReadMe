namespace ReadMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "BookTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Books", "BookTypeId");
            AddForeignKey("dbo.Books", "BookTypeId", "dbo.BookTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookTypeId", "dbo.BookTypes");
            DropIndex("dbo.Books", new[] { "BookTypeId" });
            DropColumn("dbo.Books", "BookTypeId");
            DropTable("dbo.BookTypes");
        }
    }
}
