using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGarden.Migrations
{
    public partial class ChangingDeviceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Devices");

            migrationBuilder.AddColumn<string>(
                name: "version",
                table: "Devices",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "version",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "DeviceType",
                table: "Devices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Devices",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
