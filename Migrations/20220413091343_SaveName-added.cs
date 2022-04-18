using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektLeg.Migrations
{
    public partial class SaveNameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SaveName",
                table: "Saves",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_SaveName_name",
                table: "Saves",
                columns: new[] { "SaveName", "name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Saves_SaveName_name",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "SaveName",
                table: "Saves");
        }
    }
}
