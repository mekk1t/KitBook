using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitBook.Models.Database.Migrations
{
    public partial class IngredientsCanHaveIcons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IconId",
                table: "IngredientTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTypes_IconId",
                table: "IngredientTypes",
                column: "IconId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientTypes_Files_IconId",
                table: "IngredientTypes",
                column: "IconId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientTypes_Files_IconId",
                table: "IngredientTypes");

            migrationBuilder.DropIndex(
                name: "IX_IngredientTypes_IconId",
                table: "IngredientTypes");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "IngredientTypes");
        }
    }
}
