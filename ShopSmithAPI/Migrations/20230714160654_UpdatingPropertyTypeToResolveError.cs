using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSmithAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingPropertyTypeToResolveError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labors_Vehicles_VehicleId1",
                table: "Labors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_CustomerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Labors_VehicleId1",
                table: "Labors");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Labors");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "Labors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Labors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerId1",
                table: "Vehicles",
                column: "CustomerId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_CustomerId1",
                table: "Vehicles",
                column: "CustomerId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labors_Vehicles_VehicleId",
                table: "Labors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_CustomerId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CustomerId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Labors_VehicleId",
                table: "Labors");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Labors",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
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
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                column: "CustomerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
