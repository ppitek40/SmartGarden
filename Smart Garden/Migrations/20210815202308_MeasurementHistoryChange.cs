using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGarden.Migrations
{
    public partial class MeasurementHistoryChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "MeasurementHistories");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "MeasurementHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "humidValue",
                table: "MeasurementHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lightValue",
                table: "MeasurementHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "soilMoisValue",
                table: "MeasurementHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tempValue",
                table: "MeasurementHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "waterValue",
                table: "MeasurementHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementHistories_DeviceId",
                table: "MeasurementHistories",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementHistories_Devices_DeviceId",
                table: "MeasurementHistories",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementHistories_Devices_DeviceId",
                table: "MeasurementHistories");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementHistories_DeviceId",
                table: "MeasurementHistories");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "MeasurementHistories");

            migrationBuilder.DropColumn(
                name: "humidValue",
                table: "MeasurementHistories");

            migrationBuilder.DropColumn(
                name: "lightValue",
                table: "MeasurementHistories");

            migrationBuilder.DropColumn(
                name: "soilMoisValue",
                table: "MeasurementHistories");

            migrationBuilder.DropColumn(
                name: "tempValue",
                table: "MeasurementHistories");

            migrationBuilder.DropColumn(
                name: "waterValue",
                table: "MeasurementHistories");

            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "MeasurementHistories",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
