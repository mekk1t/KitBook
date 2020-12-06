using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Database.Migrations
{
    public partial class ReworkDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "CookingTime",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CookingType",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DishType",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeType",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "CookingTimeMinutes",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CookingTypeId",
                table: "Recipes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DishTypeId",
                table: "Recipes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeTypeId",
                table: "Recipes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientTypeId",
                table: "Ingredients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CookingType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CookingTypeId",
                table: "Recipes",
                column: "CookingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DishTypeId",
                table: "Recipes",
                column: "DishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeTypeId",
                table: "Recipes",
                column: "RecipeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientTypeId",
                table: "Ingredients",
                column: "IngredientTypeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "CookingType");

            migrationBuilder.DropTable(
                name: "DishType");

            migrationBuilder.DropTable(
                name: "IngredientType");

            migrationBuilder.DropTable(
                name: "RecipeType");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CookingTypeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_DishTypeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeTypeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientTypeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CookingTimeMinutes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CookingTypeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DishTypeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeTypeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientTypeId",
                table: "Ingredients");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CookingTime",
                table: "Recipes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "CookingType",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DishType",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeType",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => new { x.RecipeId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_CategoryId",
                table: "Images",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RecipeId",
                table: "Images",
                column: "RecipeId",
                unique: true,
                filter: "[RecipeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_StageId",
                table: "Images",
                column: "StageId",
                unique: true,
                filter: "[StageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId");
        }
    }
}
