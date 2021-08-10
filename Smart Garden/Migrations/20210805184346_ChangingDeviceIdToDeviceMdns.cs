using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGarden.Migrations
{
    public partial class ChangingDeviceIdToDeviceMdns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "Devices",
                newName: "DeviceMdns");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeviceMdns",
                table: "Devices",
                newName: "DeviceId");
        }
    }
}
