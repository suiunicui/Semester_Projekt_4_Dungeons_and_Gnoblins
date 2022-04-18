using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektLeg.Migrations
{
    public partial class SaveNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Saves_SaveName_name",
                table: "Saves");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_SaveName_name",
                table: "Saves",
                columns: new[] { "SaveName", "name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Saves_SaveName_name",
                table: "Saves");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_SaveName_name",
                table: "Saves",
                columns: new[] { "SaveName", "name" });
        }
    }
}
