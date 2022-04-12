namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Title", c => c.String());
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "AddedDate");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.Genres");
        }
    }
}
