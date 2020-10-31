using Microsoft.EntityFrameworkCore.Migrations;

namespace KitBook.Models.Database.Migrations
{
    public partial class AddedTypesDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientType_IngredientTypeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_CookingType_CookingTypeId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_DishType_DishTypeId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeType_RecipeTypeId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeType",
                table: "RecipeType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientType",
                table: "IngredientType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishType",
                table: "DishType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CookingType",
                table: "CookingType");

            migrationBuilder.RenameTable(
                name: "RecipeType",
                newName: "RecipeTypes");

            migrationBuilder.RenameTable(
                name: "IngredientType",
                newName: "IngredientTypes");

            migrationBuilder.RenameTable(
                name: "DishType",
                newName: "DishTypes");

            migrationBuilder.RenameTable(
                name: "CookingType",
                newName: "CookingTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTypes",
                table: "RecipeTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientTypes",
                table: "IngredientTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishTypes",
                table: "DishTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookingTypes",
                table: "CookingTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientTypes_IngredientTypeId",
                table: "Ingredients",
                column: "IngredientTypeId",
                principalTable: "IngredientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_CookingTypes_CookingTypeId",
                table: "Recipes",
                column: "CookingTypeId",
                principalTable: "CookingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_DishTypes_DishTypeId",
                table: "Recipes",
                column: "DishTypeId",
                principalTable: "DishTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeTypes_RecipeTypeId",
                table: "Recipes",
                column: "RecipeTypeId",
                principalTable: "RecipeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientTypes_IngredientTypeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_CookingTypes_CookingTypeId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_DishTypes_DishTypeId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeTypes_RecipeTypeId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTypes",
                table: "RecipeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientTypes",
                table: "IngredientTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishTypes",
                table: "DishTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CookingTypes",
                table: "CookingTypes");

            migrationBuilder.RenameTable(
                name: "RecipeTypes",
                newName: "RecipeType");

            migrationBuilder.RenameTable(
                name: "IngredientTypes",
                newName: "IngredientType");

            migrationBuilder.RenameTable(
                name: "DishTypes",
                newName: "DishType");

            migrationBuilder.RenameTable(
                name: "CookingTypes",
                newName: "CookingType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeType",
                table: "RecipeType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientType",
                table: "IngredientType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishType",
                table: "DishType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookingType",
                table: "CookingType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientType_IngredientTypeId",
                table: "Ingredients",
                column: "IngredientTypeId",
                principalTable: "IngredientType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_CookingType_CookingTypeId",
                table: "Recipes",
                column: "CookingTypeId",
                principalTable: "CookingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_DishType_DishTypeId",
                table: "Recipes",
                column: "DishTypeId",
                principalTable: "DishType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeType_RecipeTypeId",
                table: "Recipes",
                column: "RecipeTypeId",
                principalTable: "RecipeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
