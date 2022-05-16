using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class health : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 1,
                column: "Health",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 2,
                column: "Health",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 3,
                column: "Health",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 4,
                column: "Health",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 5,
                column: "Health",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$a0cBl.aqZ0oJ8cM/qM.2euSjSDYdvehOv1BeekubHEg6hA/y0z2mS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 1,
                column: "Health",
                value: null);

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 2,
                column: "Health",
                value: null);

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 3,
                column: "Health",
                value: null);

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 4,
                column: "Health",
                value: null);

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 5,
                column: "Health",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$Dp/QoGReQdn66b8elwq9WufXZqTYpled4dReD9OIg0e7YnVRp33Wq");
        }
    }
}
