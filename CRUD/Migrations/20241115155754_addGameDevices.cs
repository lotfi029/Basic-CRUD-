using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class addGameDevices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevice_Devices_GameId",
                table: "GameDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDevice_Games_GameId",
                table: "GameDevice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDevice",
                table: "GameDevice");

            migrationBuilder.RenameTable(
                name: "GameDevice",
                newName: "GameDevices");

            migrationBuilder.RenameIndex(
                name: "IX_GameDevice_GameId",
                table: "GameDevices",
                newName: "IX_GameDevices_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDevices",
                table: "GameDevices",
                columns: new[] { "DeviceId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_Devices_GameId",
                table: "GameDevices",
                column: "GameId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_Games_GameId",
                table: "GameDevices",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_Devices_GameId",
                table: "GameDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_Games_GameId",
                table: "GameDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDevices",
                table: "GameDevices");

            migrationBuilder.RenameTable(
                name: "GameDevices",
                newName: "GameDevice");

            migrationBuilder.RenameIndex(
                name: "IX_GameDevices_GameId",
                table: "GameDevice",
                newName: "IX_GameDevice_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDevice",
                table: "GameDevice",
                columns: new[] { "DeviceId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevice_Devices_GameId",
                table: "GameDevice",
                column: "GameId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevice_Games_GameId",
                table: "GameDevice",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
