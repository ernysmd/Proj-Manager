using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSmithAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedListOFVehiclesToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labors_Users_EmployeeId",
                table: "Labors");

            migrationBuilder.DropForeignKey(
                name: "FK_Labors_Vehicles_VehicleId",
                table: "Labors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_CustomerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Labors_EmployeeId",
                table: "Labors");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Vehicles",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                newName: "IX_Vehicles_customerId");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Labors",
                newName: "vehicleId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Labors",
                newName: "employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Labors_VehicleId",
                table: "Labors",
                newName: "IX_Labors_vehicleId");

            migrationBuilder.AlterColumn<Guid>(
                name: "customerId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "vehicleId",
                table: "Labors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Labors_Vehicles_vehicleId",
                table: "Labors",
                column: "vehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_customerId",
                table: "Vehicles",
                column: "customerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labors_Vehicles_vehicleId",
                table: "Labors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_customerId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Vehicles",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_customerId",
                table: "Vehicles",
                newName: "IX_Vehicles_CustomerId");

            migrationBuilder.RenameColumn(
                name: "vehicleId",
                table: "Labors",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "Labors",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Labors_vehicleId",
                table: "Labors",
                newName: "IX_Labors_VehicleId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "Labors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Labors_EmployeeId",
                table: "Labors",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labors_Users_EmployeeId",
                table: "Labors",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labors_Vehicles_VehicleId",
                table: "Labors",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
