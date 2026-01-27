using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMT.CineHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "MovieTheater",
                columns: table => new
                {
                    MovieTheaterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheater", x => x.MovieTheaterId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Names = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surnames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "MovieMovieTheater",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieTheaterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieTheater", x => new { x.MovieId, x.MovieTheaterId });
                    table.ForeignKey(
                        name: "FK_MovieMovieTheater_MovieTheater_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheater",
                        principalColumn: "MovieTheaterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMovieTheater_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieMovieTheater_MovieTheaterId",
                table: "MovieMovieTheater",
                column: "MovieTheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieMovieTheater");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MovieTheater");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
