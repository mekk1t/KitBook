using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Database.Migrations
{
    public partial class UpdateTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RecipeType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "IngredientType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DishType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RecipeType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "IngredientType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DishType");
        }
    }
}
