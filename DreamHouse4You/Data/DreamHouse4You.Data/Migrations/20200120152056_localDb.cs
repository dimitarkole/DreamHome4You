using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamHouse4You.Data.Migrations
{
    public partial class localDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceValue",
                table: "Houses");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Houses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Houses");

            migrationBuilder.AddColumn<string>(
                name: "PriceValue",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
