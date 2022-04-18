using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektLeg.Migrations
{
    public partial class NewProperties2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username_Password",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username_Password",
                table: "Users",
                columns: new[] { "Username", "Password" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username_Password",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username_Password",
                table: "Users",
                columns: new[] { "Username", "Password" });
        }
    }
}
