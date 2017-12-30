namespace ReadMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBookTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (1, 'poz_luz')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (2, 'poz_wciag')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (3, 'luz_wciag')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (4, 'poz_luz_wciag')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (5, 'ref_wciag')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (6, 'ref_lzy')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (7, 'lzy_wciag')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (8, 'ref_lzy_wciag')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (9, 'dreszcz_wciag')");
            Sql("INSERT INTO BookTypes (Id, Name) VALUES (10, 'luz_dreszcz')");            
        }
        
        public override void Down()
        {
        }
    }
}
