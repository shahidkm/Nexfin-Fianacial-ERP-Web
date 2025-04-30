using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class StockItemEdited3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_StockCategories_CategoryId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_CategoryId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "StockItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "StockItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_CategoryId",
                table: "StockItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_StockCategories_CategoryId",
                table: "StockItems",
                column: "CategoryId",
                principalTable: "StockCategories",
                principalColumn: "StockCategoryId");
        }
    }
}
