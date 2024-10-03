using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumia.Migrations
{
    /// <inheritdoc />
    public partial class DeleteImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Images_ImageId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Images_ImageId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Images_ImageId",
                table: "SubCategories");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_ImageId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ImageId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ImageId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Brands_ImageId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "SubCategories",
                newName: "SubCategoryName");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "SubCategoryName",
                table: "SubCategories",
                newName: "CategoryName");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "SubCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_ImageId",
                table: "SubCategories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ImageId",
                table: "Departments",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ImageId",
                table: "Brands",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Images_ImageId",
                table: "Brands",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Images_ImageId",
                table: "Departments",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Images_ImageId",
                table: "SubCategories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId");
        }
    }
}
