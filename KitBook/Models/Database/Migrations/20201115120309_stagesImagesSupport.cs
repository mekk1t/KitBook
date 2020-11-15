using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitBook.Models.Database.Migrations
{
    public partial class stagesImagesSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Stages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Stages");
        }
    }
}
