using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Database.Migrations
{
    public partial class imagescontenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageExtension",
                table: "Stages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailExtension",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageExtension",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "ThumbnailExtension",
                table: "Recipes");
        }
    }
}
