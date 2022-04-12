namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreAndMoviesTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(GenreId,Description) VALUES(1,'Comedy')");
            Sql("INSERT INTO Genres(GenreId,Description) VALUES(2,'Action')");
            Sql("INSERT INTO Genres(GenreId,Description) VALUES(3,'Family')");
            Sql("INSERT INTO Genres(GenreId,Description) VALUES(4,'Romance')");
            
        }

        public override void Down()
        {
        }
    }
}
