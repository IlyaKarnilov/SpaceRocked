using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceRocket.Data.Migrations
{
    public partial class Capacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Сapacity",
                table: "Tank",
                newName: "Capacity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Tank",
                newName: "Сapacity");
        }
    }
}
