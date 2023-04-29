using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubcategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoriaId",
                table: "Subcategories");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Subcategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_CategoriaId",
                table: "Subcategories",
                newName: "IX_Subcategories_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Subcategories",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                newName: "IX_Subcategories_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoriaId",
                table: "Subcategories",
                column: "CategoriaId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
