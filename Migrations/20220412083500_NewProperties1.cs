using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektLeg.Migrations
{
    public partial class NewProperties1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Armour_ID",
                table: "Saves",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Health",
                table: "Saves",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weapon_ID",
                table: "Saves",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Armour_ID",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "Health",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "Weapon_ID",
                table: "Saves");
        }
    }
}
