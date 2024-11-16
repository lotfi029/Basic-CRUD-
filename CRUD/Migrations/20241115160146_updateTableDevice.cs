using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class updateTableDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_Devices_GameId",
                table: "GameDevices");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_Devices_DeviceId",
                table: "GameDevices",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_Devices_DeviceId",
                table: "GameDevices");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_Devices_GameId",
                table: "GameDevices",
                column: "GameId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
