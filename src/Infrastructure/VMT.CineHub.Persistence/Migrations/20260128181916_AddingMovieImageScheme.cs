using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMT.CineHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingMovieImageScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieImage",
                columns: table => new
                {
                    MovieImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieImage", x => x.MovieImageId);
                    table.ForeignKey(
                        name: "FK_MovieImage_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieImage_MovieId",
                table: "MovieImage",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieImage");
        }
    }
}
