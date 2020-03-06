using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesSearch.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IMDB3",
                columns: table => new
                {
                    SN = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 30, nullable: false),
                    ReleaseYear = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Stars = table.Column<string>(nullable: true),
                    Descreption = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDB3", x => x.SN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMDB3");
        }
    }
}
