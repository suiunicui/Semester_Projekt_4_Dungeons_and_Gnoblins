using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_API.Migrations
{
    public partial class addedListOfVisitedRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitedRooms",
                columns: table => new
                {
                    VistedRoomId = table.Column<long>(type: "bigint", nullable: false),
                    SaveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitedRooms", x => new { x.SaveId, x.VistedRoomId });
                    table.ForeignKey(
                        name: "FK_VisitedRooms_Saves_SaveId",
                        column: x => x.SaveId,
                        principalTable: "Saves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VisitedRooms",
                columns: new[] { "SaveId", "VistedRoomId" },
                values: new object[,]
                {
                    { 1, 1L },
                    { 1, 2L },
                    { 1, 3L },
                    { 1, 4L },
                    { 1, 5L },
                    { 1, 6L },
                    { 1, 7L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitedRooms");
        }
    }
}
