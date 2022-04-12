namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesDT : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Title, ReleaseDate,AddedDate,NumberInStock,GenreId) VALUES('HangOver', '2022/04/04','2020/04/04', 5, 1)");
            Sql("INSERT INTO Movies(Title, ReleaseDate,AddedDate,NumberInStock,GenreId) VALUES('Die Hard', '2022/03/03','2020/03/03', 6, 2)");
            Sql("INSERT INTO Movies(Title, ReleaseDate,AddedDate,NumberInStock,GenreId) VALUES('Terminator', '2022/02/02','2020/02/02', 7, 3)");
            Sql("INSERT INTO Movies(Title, ReleaseDate,AddedDate,NumberInStock,GenreId) VALUES('Toy Story', '2022/01/01','2020/01/01', 8, 4)");
            Sql("INSERT INTO Movies(Title, ReleaseDate,AddedDate,NumberInStock,GenreId) VALUES('Titanic', '2022/05/05','2020/05/05', 4, 1)");

        }

        public override void Down()
        {
        }
    }
}
