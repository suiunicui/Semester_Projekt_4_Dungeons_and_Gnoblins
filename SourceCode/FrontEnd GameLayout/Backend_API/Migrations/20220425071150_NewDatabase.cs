using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SaveName",
                table: "Saves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RoomDescriptions",
                columns: table => new
                {
                    RoomDescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDescriptions", x => x.RoomDescriptionID);
                });

            migrationBuilder.InsertData(
                table: "RoomDescriptions",
                columns: new[] { "RoomDescriptionID", "Description" },
                values: new object[,]
                {
                    { 1, "This is room 1" },
                    { 2, "This is room 2" },
                    { 3, "This is room 3" },
                    { 4, "This is room 4" },
                    { 5, "This is room 5" },
                    { 6, "This is room 6" },
                    { 7, "This is room 7" },
                    { 8, "This is room 8" },
                    { 9, "This is room 9" },
                    { 10, "This is room 10" },
                    { 11, "This is room 11" },
                    { 12, "This is room 12" },
                    { 13, "This is room 13" },
                    { 14, "This is room 14" },
                    { 15, "This is room 15" },
                    { 16, "This is room 16" },
                    { 17, "This is room 17" },
                    { 18, "This is room 18" },
                    { 19, "This is room 19" },
                    { 20, "This is room 20" }
                });

            migrationBuilder.InsertData(
                table: "Saves",
                columns: new[] { "ID", "RoomID", "SaveName", "UserId" },
                values: new object[,]
                {
                    { 1, 12, "AndersGame2", null },
                    { 2, 14, "LuyenGame1", null },
                    { 3, 3, "MortenGame", null },
                    { 4, 4, "ODGame", null },
                    { 5, 5, "SuneGame", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomDescriptions");

            migrationBuilder.DeleteData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "SaveName",
                table: "Saves");
        }
    }
}
