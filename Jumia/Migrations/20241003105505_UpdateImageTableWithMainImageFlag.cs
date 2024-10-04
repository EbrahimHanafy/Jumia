using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumia.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageTableWithMainImageFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainImage",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainImage",
                table: "ProductImages");
        }
    }
}
