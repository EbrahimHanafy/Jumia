using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumia.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    UserPermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.UserPermissionId);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermissions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivateClient = table.Column<bool>(type: "bit", nullable: false),
                    ActivateProduct = table.Column<bool>(type: "bit", nullable: false),
                    AddBrand = table.Column<bool>(type: "bit", nullable: false),
                    AddCategory = table.Column<bool>(type: "bit", nullable: false),
                    AddCountry = table.Column<bool>(type: "bit", nullable: false),
                    AddDepartment = table.Column<bool>(type: "bit", nullable: false),
                    AddOrderStatus = table.Column<bool>(type: "bit", nullable: false),
                    AddPaymentMethod = table.Column<bool>(type: "bit", nullable: false),
                    AddProduct = table.Column<bool>(type: "bit", nullable: false),
                    AddStore = table.Column<bool>(type: "bit", nullable: false),
                    AddSubCategory = table.Column<bool>(type: "bit", nullable: false),
                    CreateDiscountCoupon = table.Column<bool>(type: "bit", nullable: false),
                    DeleteProduct = table.Column<bool>(type: "bit", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    SeeClientInfo = table.Column<bool>(type: "bit", nullable: false),
                    SeeClientOrders = table.Column<bool>(type: "bit", nullable: false),
                    SeeClientShippingCart = table.Column<bool>(type: "bit", nullable: false),
                    SeeClientWishList = table.Column<bool>(type: "bit", nullable: false),
                    SeeStoreInfo = table.Column<bool>(type: "bit", nullable: false),
                    StopDiscountCoupon = table.Column<bool>(type: "bit", nullable: false),
                    UpdateBrand = table.Column<bool>(type: "bit", nullable: false),
                    UpdateCategory = table.Column<bool>(type: "bit", nullable: false),
                    UpdateClientInfo = table.Column<bool>(type: "bit", nullable: false),
                    UpdateCountry = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDepartment = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDiscountCoupon = table.Column<bool>(type: "bit", nullable: false),
                    UpdateOrderStatus = table.Column<bool>(type: "bit", nullable: false),
                    UpdatePaymentMethod = table.Column<bool>(type: "bit", nullable: false),
                    UpdateProductDiscount = table.Column<bool>(type: "bit", nullable: false),
                    UpdateProductInfo = table.Column<bool>(type: "bit", nullable: false),
                    UpdateProductPrice = table.Column<bool>(type: "bit", nullable: false),
                    UpdateStoreInfo = table.Column<bool>(type: "bit", nullable: false),
                    UpdateStoreProducts = table.Column<bool>(type: "bit", nullable: false),
                    UpdateSubCategory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
