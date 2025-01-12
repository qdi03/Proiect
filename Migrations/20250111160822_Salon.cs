using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    /// <inheritdoc />
    public partial class Salon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalonID",
                table: "Tatuaj",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeSalon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tatuaj_SalonID",
                table: "Tatuaj",
                column: "SalonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tatuaj_Salon_SalonID",
                table: "Tatuaj",
                column: "SalonID",
                principalTable: "Salon",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tatuaj_Salon_SalonID",
                table: "Tatuaj");

            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropIndex(
                name: "IX_Tatuaj_SalonID",
                table: "Tatuaj");

            migrationBuilder.DropColumn(
                name: "SalonID",
                table: "Tatuaj");
        }
    }
}
