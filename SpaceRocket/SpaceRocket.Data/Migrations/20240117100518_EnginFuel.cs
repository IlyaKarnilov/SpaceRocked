using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceRocket.Data.Migrations
{
    public partial class EnginFuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Engine");

            migrationBuilder.AddColumn<Guid>(
                name: "FuelTypeId",
                table: "Engine",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Engine_FuelTypeId",
                table: "Engine",
                column: "FuelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engine_Fuel_FuelTypeId",
                table: "Engine",
                column: "FuelTypeId",
                principalTable: "Fuel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engine_Fuel_FuelTypeId",
                table: "Engine");

            migrationBuilder.DropIndex(
                name: "IX_Engine_FuelTypeId",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "Engine");

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Engine",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
