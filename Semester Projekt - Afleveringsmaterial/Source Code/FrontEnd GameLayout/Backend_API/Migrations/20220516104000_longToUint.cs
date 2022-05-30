using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class longToUint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_Saves_saveID",
                table: "Puzzles");

            migrationBuilder.DropIndex(
                name: "IX_Puzzles_saveID",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "saveID",
                table: "Puzzles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$Dp/QoGReQdn66b8elwq9WufXZqTYpled4dReD9OIg0e7YnVRp33Wq");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_Save_ID",
                table: "Puzzles",
                column: "Save_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_Saves_Save_ID",
                table: "Puzzles",
                column: "Save_ID",
                principalTable: "Saves",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_Saves_Save_ID",
                table: "Puzzles");

            migrationBuilder.DropIndex(
                name: "IX_Puzzles_Save_ID",
                table: "Puzzles");

            migrationBuilder.AddColumn<int>(
                name: "saveID",
                table: "Puzzles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$JSXMHm8lPkMHEpWITIcMW.am/qd7UfeeQXwQ0IPDrQK84mvKY.E8O");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_saveID",
                table: "Puzzles",
                column: "saveID");

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_Saves_saveID",
                table: "Puzzles",
                column: "saveID",
                principalTable: "Saves",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
