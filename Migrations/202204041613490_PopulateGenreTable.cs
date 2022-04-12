namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Description) VALUES('Comedy')");
            Sql("INSERT INTO Genres(Description) VALUES('Action')");
            Sql("INSERT INTO Genres(Description) VALUES('Family')");
            Sql("INSERT INTO Genres(Description) VALUES('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
