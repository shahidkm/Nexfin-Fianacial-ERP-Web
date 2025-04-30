using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GSTTaxDetail_VoucherItems_VoucherItemId",
                table: "GSTTaxDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GSTTaxDetail",
                table: "GSTTaxDetail");

            migrationBuilder.RenameTable(
                name: "GSTTaxDetail",
                newName: "GSTTaxDetails");

            migrationBuilder.RenameIndex(
                name: "IX_GSTTaxDetail_VoucherItemId",
                table: "GSTTaxDetails",
                newName: "IX_GSTTaxDetails_VoucherItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GSTTaxDetails",
                table: "GSTTaxDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GSTTaxDetails_VoucherItems_VoucherItemId",
                table: "GSTTaxDetails",
                column: "VoucherItemId",
                principalTable: "VoucherItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GSTTaxDetails_VoucherItems_VoucherItemId",
                table: "GSTTaxDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GSTTaxDetails",
                table: "GSTTaxDetails");

            migrationBuilder.RenameTable(
                name: "GSTTaxDetails",
                newName: "GSTTaxDetail");

            migrationBuilder.RenameIndex(
                name: "IX_GSTTaxDetails_VoucherItemId",
                table: "GSTTaxDetail",
                newName: "IX_GSTTaxDetail_VoucherItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GSTTaxDetail",
                table: "GSTTaxDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GSTTaxDetail_VoucherItems_VoucherItemId",
                table: "GSTTaxDetail",
                column: "VoucherItemId",
                principalTable: "VoucherItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
