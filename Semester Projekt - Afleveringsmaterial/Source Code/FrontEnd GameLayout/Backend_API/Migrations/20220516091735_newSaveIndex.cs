using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class newSaveIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$JSXMHm8lPkMHEpWITIcMW.am/qd7UfeeQXwQ0IPDrQK84mvKY.E8O");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$vi/4f.Vex8q10mET9YYy9eawL0s6/4xUDdp71zmdG0OmCKJbl1ki6");
        }
    }
}
