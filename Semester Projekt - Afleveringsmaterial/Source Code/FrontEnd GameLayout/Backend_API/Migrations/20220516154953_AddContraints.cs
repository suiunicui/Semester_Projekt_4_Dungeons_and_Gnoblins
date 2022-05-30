using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class AddContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_Saves_saveID",
                table: "Puzzles");

            migrationBuilder.DropIndex(
                name: "IX_Puzzles_saveID",
                table: "Puzzles");

            migrationBuilder.DropIndex(
                name: "IX_Items_SaveID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Enemies_SaveID",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "saveID",
                table: "Puzzles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puzzles",
                table: "Puzzles",
                columns: new[] { "Save_ID", "Puzzles_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                columns: new[] { "SaveID", "ItemID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enemies",
                table: "Enemies",
                columns: new[] { "SaveID", "EnemyID" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$jW9/.SbTTKvoUx1sCVOtZON9Jctx9Caai9BTwNxp1tgqyZfQ5.HJ6");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puzzles",
                table: "Puzzles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enemies",
                table: "Enemies");

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
                value: "$2a$11$AgRdIQm3FIkKa1ZMvM4VWuhhth2QFhMvS3WRdXyiZiAkCVlpwGzY6");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_saveID",
                table: "Puzzles",
                column: "saveID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SaveID",
                table: "Items",
                column: "SaveID");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_SaveID",
                table: "Enemies",
                column: "SaveID");

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
