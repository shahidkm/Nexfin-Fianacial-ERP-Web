using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class AllUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Vouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Vouchers");
        }
    }
}
