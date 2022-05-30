using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class NewFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Armour_ID",
                table: "Saves",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Health",
                table: "Saves",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weapon_ID",
                table: "Saves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    EnemyID = table.Column<int>(type: "int", nullable: false),
                    SaveID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => new { x.SaveID, x.EnemyID });
                    table.ForeignKey(
                        name: "FK_Enemies_Saves_SaveID",
                        column: x => x.SaveID,
                        principalTable: "Saves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    SaveID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => new { x.SaveID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_Items_Saves_SaveID",
                        column: x => x.SaveID,
                        principalTable: "Saves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puzzles",
                columns: table => new
                {
                    Puzzles_ID = table.Column<int>(type: "int", nullable: false),
                    Save_ID = table.Column<int>(type: "int", nullable: false),
                    saveID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puzzles", x => new { x.Puzzles_ID, x.Save_ID });
                    table.ForeignKey(
                        name: "FK_Puzzles_Saves_saveID",
                        column: x => x.saveID,
                        principalTable: "Saves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$vi/4f.Vex8q10mET9YYy9eawL0s6/4xUDdp71zmdG0OmCKJbl1ki6");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_saveID",
                table: "Puzzles",
                column: "saveID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Puzzles");

            migrationBuilder.DropColumn(
                name: "Armour_ID",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "Health",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "Weapon_ID",
                table: "Saves");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Gamer1",
                column: "Password",
                value: "$2a$11$x1X9.t6nbT2ExZWDc9XtEOCpxqXsMh5PLn90r3lchIF2f10JiLaBO");
        }
    }
}
