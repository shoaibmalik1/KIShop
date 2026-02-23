using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KIShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CraetedBy",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Users_CraetedBy",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "CraetedBy",
                table: "products",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_products_CraetedBy",
                table: "products",
                newName: "IX_products_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CraetedBy",
                table: "Categories",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CraetedBy",
                table: "Categories",
                newName: "IX_Categories_CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedBy",
                table: "Categories",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Users_CreatedBy",
                table: "products",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedBy",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Users_CreatedBy",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "products",
                newName: "CraetedBy");

            migrationBuilder.RenameIndex(
                name: "IX_products_CreatedBy",
                table: "products",
                newName: "IX_products_CraetedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Categories",
                newName: "CraetedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CreatedBy",
                table: "Categories",
                newName: "IX_Categories_CraetedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CraetedBy",
                table: "Categories",
                column: "CraetedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Users_CraetedBy",
                table: "products",
                column: "CraetedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
