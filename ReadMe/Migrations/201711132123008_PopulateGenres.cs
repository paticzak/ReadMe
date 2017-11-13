namespace ReadMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Dramat')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Krymina³')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Romans')");
        }
        
        public override void Down()
        {
        }
    }
}
