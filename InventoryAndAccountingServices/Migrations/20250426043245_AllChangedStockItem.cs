using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class AllChangedStockItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GstRate",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HsnSacCode",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsGstApplicable",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfSupply",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GstRate",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "HsnSacCode",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "IsGstApplicable",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "TypeOfSupply",
                table: "StockItems");
        }
    }
}
