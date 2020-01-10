using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamHouse4You.Data.Migrations
{
    public partial class EditEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_ParentCategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ParentCategoryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentCategoryId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ParentCategoryId",
                table: "Events",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_ParentCategoryId",
                table: "Events",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
