using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektLeg.Migrations
{
    public partial class NewProperties3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Users_user_ID",
                table: "Saves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Saves_user_ID",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "user_ID",
                table: "Saves");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Saves",
                type: "nvarchar(64)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_name",
                table: "Saves",
                column: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Users_name",
                table: "Saves",
                column: "name",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Users_name",
                table: "Saves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Saves_name",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Saves");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "user_ID",
                table: "Saves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_user_ID",
                table: "Saves",
                column: "user_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Users_user_ID",
                table: "Saves",
                column: "user_ID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
