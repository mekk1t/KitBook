using Microsoft.EntityFrameworkCore.Migrations;

namespace KitBook.Models.Database.Migrations
{
    public partial class imagesContentType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageExtension",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "ThumbnailExtension",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "Stages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailContentType",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "ThumbnailContentType",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "ImageExtension",
                table: "Stages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailExtension",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
