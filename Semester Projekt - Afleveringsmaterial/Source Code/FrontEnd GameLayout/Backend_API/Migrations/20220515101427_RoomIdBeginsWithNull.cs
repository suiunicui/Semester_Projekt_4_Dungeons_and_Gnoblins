using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class RoomIdBeginsWithNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 0, "gamer1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 0, "gamer1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 0, "gamer1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 0, "gamer1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 0, "gamer1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$x1X9.t6nbT2ExZWDc9XtEOCpxqXsMh5PLn90r3lchIF2f10JiLaBO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 1, "Gamer1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 1, "Gamer1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 1, "Gamer1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 1, "Gamer1" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "RoomID", "Username" },
                values: new object[] { 1, "Gamer1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$kqFgv5.ZGVv7aoDyr6gW2uOiWKr7BxTxnKTwEffuRpUAsJwPHtThy");
        }
    }
}
