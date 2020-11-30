using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitBook.Models.Database.Migrations
{
    public partial class TypeIcons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IconId",
                table: "RecipeTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IconId",
                table: "DishTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IconId",
                table: "CookingTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTypes_IconId",
                table: "RecipeTypes",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTypes_IconId",
                table: "DishTypes",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingTypes_IconId",
                table: "CookingTypes",
                column: "IconId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookingTypes_Files_IconId",
                table: "CookingTypes",
                column: "IconId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishTypes_Files_IconId",
                table: "DishTypes",
                column: "IconId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTypes_Files_IconId",
                table: "RecipeTypes",
                column: "IconId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookingTypes_Files_IconId",
                table: "CookingTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishTypes_Files_IconId",
                table: "DishTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTypes_Files_IconId",
                table: "RecipeTypes");

            migrationBuilder.DropIndex(
                name: "IX_RecipeTypes_IconId",
                table: "RecipeTypes");

            migrationBuilder.DropIndex(
                name: "IX_DishTypes_IconId",
                table: "DishTypes");

            migrationBuilder.DropIndex(
                name: "IX_CookingTypes_IconId",
                table: "CookingTypes");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "RecipeTypes");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "DishTypes");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "CookingTypes");
        }
    }
}
