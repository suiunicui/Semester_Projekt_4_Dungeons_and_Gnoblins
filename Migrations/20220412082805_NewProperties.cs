using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektLeg.Migrations
{
    public partial class NewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Saves",
                columns: table => new
                {
                    SaveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    user_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saves", x => x.SaveID);
                    table.ForeignKey(
                        name: "FK_Saves_Users_user_ID",
                        column: x => x.user_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "SaveID",
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
                        principalColumn: "SaveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puzzles",
                columns: table => new
                {
                    Puzzles_ID = table.Column<int>(type: "int", nullable: false),
                    Save_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puzzles", x => new { x.Puzzles_ID, x.Save_ID });
                    table.ForeignKey(
                        name: "FK_Puzzles_Saves_Save_ID",
                        column: x => x.Save_ID,
                        principalTable: "Saves",
                        principalColumn: "SaveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_Save_ID",
                table: "Puzzles",
                column: "Save_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_user_ID",
                table: "Saves",
                column: "user_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username_Password",
                table: "Users",
                columns: new[] { "Username", "Password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Puzzles");

            migrationBuilder.DropTable(
                name: "Saves");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
