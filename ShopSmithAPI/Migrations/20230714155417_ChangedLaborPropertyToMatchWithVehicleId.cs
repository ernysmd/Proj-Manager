using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSmithAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedLaborPropertyToMatchWithVehicleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labors_Vehicles_VehicleId1",
                table: "Labors");

            migrationBuilder.DropIndex(
                name: "IX_Labors_VehicleId1",
                table: "Labors");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Labors");

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "Labors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Labors_VehicleId",
                table: "Labors",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labors_Vehicles_VehicleId",
                table: "Labors",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labors_Vehicles_VehicleId",
                table: "Labors");

            migrationBuilder.DropIndex(
                name: "IX_Labors_VehicleId",
                table: "Labors");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Labors",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId1",
                table: "Labors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labors_VehicleId1",
                table: "Labors",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Labors_Vehicles_VehicleId1",
                table: "Labors",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
