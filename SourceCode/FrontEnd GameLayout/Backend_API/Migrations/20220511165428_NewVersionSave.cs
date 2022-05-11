using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class NewVersionSave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Users_UserId",
                table: "Saves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Saves_UserId",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Saves");

            migrationBuilder.AlterColumn<string>(
                name: "SaveName",
                table: "Saves",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Saves",
                type: "nvarchar(64)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Username");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password" },
                values: new object[] { "Gamer1", "$2a$11$kqFgv5.ZGVv7aoDyr6gW2uOiWKr7BxTxnKTwEffuRpUAsJwPHtThy" });

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 1,
                column: "Username",
                value: "Gamer1");

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 2,
                column: "Username",
                value: "Gamer1");

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 3,
                column: "Username",
                value: "Gamer1");

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 4,
                column: "Username",
                value: "Gamer1");

            migrationBuilder.UpdateData(
                table: "Saves",
                keyColumn: "ID",
                keyValue: 5,
                column: "Username",
                value: "Gamer1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username_Password",
                table: "Users",
                columns: new[] { "Username", "Password" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saves_SaveName_Username",
                table: "Saves",
                columns: new[] { "SaveName", "Username" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saves_Username",
                table: "Saves",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Users_Username",
                table: "Saves",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Users_Username",
                table: "Saves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username_Password",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Saves_SaveName_Username",
                table: "Saves");

            migrationBuilder.DropIndex(
                name: "IX_Saves_Username",
                table: "Saves");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Saves");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "SaveName",
                table: "Saves",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Saves",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_UserId",
                table: "Saves",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Users_UserId",
                table: "Saves",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
