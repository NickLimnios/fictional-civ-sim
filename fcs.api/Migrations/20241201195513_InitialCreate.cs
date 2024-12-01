using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fcs.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Civilizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Population = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Climate = table.Column<string>(type: "TEXT", nullable: true),
                    Culture = table.Column<string>(type: "TEXT", nullable: true),
                    Technology = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Civilizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CivilizationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Civilizations_CivilizationId",
                        column: x => x.CivilizationId,
                        principalTable: "Civilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CivilizationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Civilizations_CivilizationId",
                        column: x => x.CivilizationId,
                        principalTable: "Civilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Civilizations",
                columns: new[] { "Id", "Climate", "Culture", "CurrentYear", "Name", "Population", "Technology" },
                values: new object[,]
                {
                    { 1, null, null, 0, "Atlantis", 250, null },
                    { 2, null, null, 0, "Babylon", 150, null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CivilizationId", "Description", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Atlantis founded.", 0 },
                    { 2, 2, "Babylon rose to power.", 0 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CivilizationId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Wood", 200 },
                    { 2, 1, "Minerals", 100 },
                    { 3, 1, "Food", 800 },
                    { 4, 2, "Wood", 100 },
                    { 5, 2, "Food", 500 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CivilizationId",
                table: "Events",
                column: "CivilizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CivilizationId",
                table: "Resources",
                column: "CivilizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Civilizations");
        }
    }
}
