using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class dropContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_Saves_Save_ID",
                table: "Puzzles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puzzles",
                table: "Puzzles");

            migrationBuilder.DropIndex(
                name: "IX_Puzzles_Save_ID",
                table: "Puzzles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enemies",
                table: "Enemies");

            migrationBuilder.AlterColumn<long>(
                name: "Puzzles_ID",
                table: "Puzzles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "saveID",
                table: "Puzzles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "ItemID",
                table: "Items",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "EnemyID",
                table: "Enemies",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Puzzles_ID",
                table: "Puzzles",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EnemyID",
                table: "Enemies",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puzzles",
                table: "Puzzles",
                columns: new[] { "Puzzles_ID", "Save_ID" });

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
                value: "$2a$11$a0cBl.aqZ0oJ8cM/qM.2euSjSDYdvehOv1BeekubHEg6hA/y0z2mS");

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
    }
}
