using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class FreshSaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VisitedRooms",
                keyColumns: new[] { "SaveId", "VistedRoomId" },
                keyValues: new object[] { 1, 1L });

            migrationBuilder.DeleteData(
                table: "VisitedRooms",
                keyColumns: new[] { "SaveId", "VistedRoomId" },
                keyValues: new object[] { 1, 2L });

            migrationBuilder.DeleteData(
                table: "VisitedRooms",
                keyColumns: new[] { "SaveId", "VistedRoomId" },
                keyValues: new object[] { 1, 3L });

            migrationBuilder.DeleteData(
                table: "VisitedRooms",
                keyColumns: new[] { "SaveId", "VistedRoomId" },
                keyValues: new object[] { 1, 4L });

            migrationBuilder.DeleteData(
                table: "VisitedRooms",
                keyColumns: new[] { "SaveId", "VistedRoomId" },
                keyValues: new object[] { 1, 5L });

            migrationBuilder.DeleteData(
                table: "VisitedRooms",
                keyColumns: new[] { "SaveId", "VistedRoomId" },
                keyValues: new object[] { 1, 6L });

            migrationBuilder.DeleteData(
                table: "VisitedRooms",
                keyColumns: new[] { "SaveId", "VistedRoomId" },
                keyValues: new object[] { 1, 7L });

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 1,
                column: "Description",
                value: "DB says: This is room 1");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 2,
                column: "Description",
                value: "DB says: This is room 2");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 3,
                column: "Description",
                value: "DB says: This is room 3");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 4,
                column: "Description",
                value: "DB says: This is room 4");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 5,
                column: "Description",
                value: "DB says: This is room 5");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 6,
                column: "Description",
                value: "DB says: This is room 6");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 7,
                column: "Description",
                value: "DB says: This is room 7");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 8,
                column: "Description",
                value: "DB says: This is room 8");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 9,
                column: "Description",
                value: "DB says: This is room 9");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 10,
                column: "Description",
                value: "DB says: This is room 10");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 11,
                column: "Description",
                value: "DB says: This is room 11");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 12,
                column: "Description",
                value: "DB says: This is room 12");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 13,
                column: "Description",
                value: "DB says: This is room 13");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 14,
                column: "Description",
                value: "DB says: This is room 14");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 15,
                column: "Description",
                value: "DB says: This is room 15");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 16,
                column: "Description",
                value: "DB says: This is room 16");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 17,
                column: "Description",
                value: "DB says: This is room 17");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 18,
                column: "Description",
                value: "DB says: This is room 18");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 19,
                column: "Description",
                value: "DB says: This is room 19");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 20,
                column: "Description",
                value: "DB says: This is room 20");

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 1, "NewGame1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 1, "NewGame2" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 1, "NewGame3" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 1, "NewGame4" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 1, "NewGame5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 1,
                column: "Description",
                value: "This is room 1");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 2,
                column: "Description",
                value: "This is room 2");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 3,
                column: "Description",
                value: "This is room 3");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 4,
                column: "Description",
                value: "This is room 4");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 5,
                column: "Description",
                value: "This is room 5");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 6,
                column: "Description",
                value: "This is room 6");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 7,
                column: "Description",
                value: "This is room 7");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 8,
                column: "Description",
                value: "This is room 8");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 9,
                column: "Description",
                value: "This is room 9");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 10,
                column: "Description",
                value: "This is room 10");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 11,
                column: "Description",
                value: "This is room 11");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 12,
                column: "Description",
                value: "This is room 12");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 13,
                column: "Description",
                value: "This is room 13");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 14,
                column: "Description",
                value: "This is room 14");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 15,
                column: "Description",
                value: "This is room 15");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 16,
                column: "Description",
                value: "This is room 16");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 17,
                column: "Description",
                value: "This is room 17");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 18,
                column: "Description",
                value: "This is room 18");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 19,
                column: "Description",
                value: "This is room 19");

            migrationBuilder.UpdateData(
                table: "RoomDescriptions",
                keyColumn: "RoomDescriptionID",
                keyValue: 20,
                column: "Description",
                value: "This is room 20");

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 12, "AndersGame2" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 14, "LuyenGame1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 3, "MortenGame" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 4, "ODGame" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "RoomID", "SaveName" },
                values: new object[] { 5, "SuneGame" });

            migrationBuilder.InsertData(
                table: "VisitedRooms",
                columns: new[] { "SaveId", "VistedRoomId" },
                values: new object[,]
                {
                    { 1, 1L },
                    { 1, 2L },
                    { 1, 3L },
                    { 1, 4L },
                    { 1, 5L },
                    { 1, 6L },
                    { 1, 7L }
                });
        }
    }
}
