using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class StockItemEdited4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_StockGroups_GroupId",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_UnitOfMeasures_UnitId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_GroupId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_UnitId",
                table: "StockItems");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "StockItems",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "StockItems");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_GroupId",
                table: "StockItems",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_UnitId",
                table: "StockItems",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_StockGroups_GroupId",
                table: "StockItems",
                column: "GroupId",
                principalTable: "StockGroups",
                principalColumn: "StockGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_UnitOfMeasures_UnitId",
                table: "StockItems",
                column: "UnitId",
                principalTable: "UnitOfMeasures",
                principalColumn: "UnitId");
        }
    }
}
