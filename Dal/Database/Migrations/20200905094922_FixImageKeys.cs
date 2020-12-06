using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Database.Migrations
{
    public partial class FixImageKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Images_ImageId1",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Stages_ImageId1",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Images_RecipeId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "ImageId1",
                table: "Stages");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Categories_CategoryId",
                table: "Images",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Stages_StageId",
                table: "Images",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Categories_CategoryId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Stages_StageId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CategoryId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_RecipeId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StageId",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Stages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId1",
                table: "Stages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ImageId1",
                table: "Stages",
                column: "ImageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RecipeId",
                table: "Images",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Images_ImageId1",
                table: "Stages",
                column: "ImageId1",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
