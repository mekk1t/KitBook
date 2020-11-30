using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitBook.Models.Database.Migrations
{
    public partial class FilesSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ThumbnailContentType",
                table: "Recipes");

            migrationBuilder.AddColumn<Guid>(
                name: "AvatarId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Stages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ThumbnailId",
                table: "Recipes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AvatarId",
                table: "Users",
                column: "AvatarId",
                unique: true,
                filter: "[AvatarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ImageId",
                table: "Stages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ThumbnailId",
                table: "Recipes",
                column: "ThumbnailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Files_ThumbnailId",
                table: "Recipes",
                column: "ThumbnailId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Files_ImageId",
                table: "Stages",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Files_AvatarId",
                table: "Users",
                column: "AvatarId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Files_ThumbnailId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Files_ImageId",
                table: "Stages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Files_AvatarId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Users_AvatarId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Stages_ImageId",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ThumbnailId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Recipes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Stages",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "Stages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Thumbnail",
                table: "Recipes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailContentType",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
