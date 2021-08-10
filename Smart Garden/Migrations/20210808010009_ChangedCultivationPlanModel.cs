using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartGarden.Migrations
{
    public partial class ChangedCultivationPlanModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Humidity",
                table: "CultivationPlans",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "BuzzerMuted",
                table: "CultivationPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LightningThreshold",
                table: "CultivationPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoilMoisMax",
                table: "CultivationPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WateringDuration",
                table: "CultivationPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WateringThreshold",
                table: "CultivationPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuzzerMuted",
                table: "CultivationPlans");

            migrationBuilder.DropColumn(
                name: "LightningThreshold",
                table: "CultivationPlans");

            migrationBuilder.DropColumn(
                name: "SoilMoisMax",
                table: "CultivationPlans");

            migrationBuilder.DropColumn(
                name: "WateringDuration",
                table: "CultivationPlans");

            migrationBuilder.DropColumn(
                name: "WateringThreshold",
                table: "CultivationPlans");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CultivationPlans",
                newName: "Humidity");
        }
    }
}
