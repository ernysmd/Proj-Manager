using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSmithAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedLaborHoursAndLaborMinutesToOnePropOfLaborTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaborHours",
                table: "Labors");

            migrationBuilder.DropColumn(
                name: "LaborMinutes",
                table: "Labors");

            migrationBuilder.AddColumn<decimal>(
                name: "LaborTime",
                table: "Labors",
                type: "decimal(4,2)",
                precision: 4,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaborTime",
                table: "Labors");

            migrationBuilder.AddColumn<decimal>(
                name: "LaborHours",
                table: "Labors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LaborMinutes",
                table: "Labors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
