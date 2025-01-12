using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    /// <inheritdoc />
    public partial class Artist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Tatuaj");

            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "Tatuaj",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tatuaj_ArtistID",
                table: "Tatuaj",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tatuaj_Artist_ArtistID",
                table: "Tatuaj",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tatuaj_Artist_ArtistID",
                table: "Tatuaj");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Tatuaj_ArtistID",
                table: "Tatuaj");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "Tatuaj");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Tatuaj",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
