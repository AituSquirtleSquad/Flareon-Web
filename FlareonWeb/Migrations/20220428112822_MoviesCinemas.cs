using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FlareonWeb.Migrations
{
    public partial class MoviesCinemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    CinemaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CinemaName = table.Column<string>(type: "text", nullable: true),
                    CinemaCity = table.Column<string>(type: "text", nullable: true),
                    CinemaAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.CinemaId);
                });

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    TheaterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TheaterName = table.Column<string>(type: "text", nullable: true),
                    TheaterCity = table.Column<string>(type: "text", nullable: true),
                    TheaterAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.TheaterId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieName = table.Column<string>(type: "text", nullable: true),
                    MovieDescription = table.Column<string>(type: "text", nullable: true),
                    MovieReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MovieGenre = table.Column<string>(type: "text", nullable: true),
                    MovieDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    MovieImage = table.Column<string>(type: "text", nullable: true),
                    MovieBackgroundImage = table.Column<string>(type: "text", nullable: true),
                    MoviePrice = table.Column<int>(type: "integer", nullable: false),
                    CinemaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "CinemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spectacles",
                columns: table => new
                {
                    SpectacleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpectacleName = table.Column<string>(type: "text", nullable: true),
                    SpectacleDescription = table.Column<string>(type: "text", nullable: true),
                    SpectacleReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SpectacleGenre = table.Column<string>(type: "text", nullable: true),
                    SpectacleDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    SpectacleImage = table.Column<string>(type: "text", nullable: true),
                    SpectacleBackgroundImage = table.Column<string>(type: "text", nullable: true),
                    SpectaclePrice = table.Column<int>(type: "integer", nullable: false),
                    TheaterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spectacles", x => x.SpectacleId);
                    table.ForeignKey(
                        name: "FK_Spectacles_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "TheaterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Spectacles_TheaterId",
                table: "Spectacles",
                column: "TheaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Spectacles");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Theaters");
        }
    }
}
