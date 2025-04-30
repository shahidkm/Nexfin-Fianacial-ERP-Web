using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class GroupClassEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllocateInPurchase",
                table: "InventoryGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetBalance",
                table: "InventoryGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubLedger",
                table: "InventoryGroups",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllocateInPurchase",
                table: "InventoryGroups");

            migrationBuilder.DropColumn(
                name: "NetBalance",
                table: "InventoryGroups");

            migrationBuilder.DropColumn(
                name: "SubLedger",
                table: "InventoryGroups");
        }
    }
}
