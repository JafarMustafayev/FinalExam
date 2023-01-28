using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilet_3.Migrations
{
    public partial class addteamList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Teams_TeamId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_TeamId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Positions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_TeamId",
                table: "Positions",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Teams_TeamId",
                table: "Positions",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
