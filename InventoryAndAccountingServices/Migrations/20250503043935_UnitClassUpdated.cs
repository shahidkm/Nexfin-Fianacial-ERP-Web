using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class UnitClassUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuantityCode",
                table: "UnitOfMeasures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityCode",
                table: "UnitOfMeasures");
        }
    }
}
