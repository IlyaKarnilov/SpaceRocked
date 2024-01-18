using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceRocket.Data.Migrations
{
    public partial class RemoveFuelFromRocket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rocket_Fuel_FuelId",
                table: "Rocket");

            migrationBuilder.DropIndex(
                name: "IX_Rocket_FuelId",
                table: "Rocket");

            migrationBuilder.DropColumn(
                name: "FuelId",
                table: "Rocket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FuelId",
                table: "Rocket",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Rocket_FuelId",
                table: "Rocket",
                column: "FuelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rocket_Fuel_FuelId",
                table: "Rocket",
                column: "FuelId",
                principalTable: "Fuel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
