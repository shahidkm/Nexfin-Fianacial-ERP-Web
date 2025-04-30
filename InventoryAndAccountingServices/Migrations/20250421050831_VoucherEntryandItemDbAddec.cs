using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class VoucherEntryandItemDbAddec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GSTTaxDetail_VoucherItem_VoucherItemId",
                table: "GSTTaxDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherEntry_InventoryLedgers_LedgerId",
                table: "VoucherEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherEntry_Vouchers_VoucherId",
                table: "VoucherEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherItem_StockItems_ItemId",
                table: "VoucherItem");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherItem_Vouchers_VoucherId",
                table: "VoucherItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoucherItem",
                table: "VoucherItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoucherEntry",
                table: "VoucherEntry");

            migrationBuilder.RenameTable(
                name: "VoucherItem",
                newName: "VoucherItems");

            migrationBuilder.RenameTable(
                name: "VoucherEntry",
                newName: "VoucherEntries");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherItem_VoucherId",
                table: "VoucherItems",
                newName: "IX_VoucherItems_VoucherId");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherItem_ItemId",
                table: "VoucherItems",
                newName: "IX_VoucherItems_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherEntry_VoucherId",
                table: "VoucherEntries",
                newName: "IX_VoucherEntries_VoucherId");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherEntry_LedgerId",
                table: "VoucherEntries",
                newName: "IX_VoucherEntries_LedgerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoucherItems",
                table: "VoucherItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoucherEntries",
                table: "VoucherEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GSTTaxDetail_VoucherItems_VoucherItemId",
                table: "GSTTaxDetail",
                column: "VoucherItemId",
                principalTable: "VoucherItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherEntries_InventoryLedgers_LedgerId",
                table: "VoucherEntries",
                column: "LedgerId",
                principalTable: "InventoryLedgers",
                principalColumn: "LedgerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherEntries_Vouchers_VoucherId",
                table: "VoucherEntries",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherItems_StockItems_ItemId",
                table: "VoucherItems",
                column: "ItemId",
                principalTable: "StockItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherItems_Vouchers_VoucherId",
                table: "VoucherItems",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GSTTaxDetail_VoucherItems_VoucherItemId",
                table: "GSTTaxDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherEntries_InventoryLedgers_LedgerId",
                table: "VoucherEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherEntries_Vouchers_VoucherId",
                table: "VoucherEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherItems_StockItems_ItemId",
                table: "VoucherItems");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherItems_Vouchers_VoucherId",
                table: "VoucherItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoucherItems",
                table: "VoucherItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoucherEntries",
                table: "VoucherEntries");

            migrationBuilder.RenameTable(
                name: "VoucherItems",
                newName: "VoucherItem");

            migrationBuilder.RenameTable(
                name: "VoucherEntries",
                newName: "VoucherEntry");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherItems_VoucherId",
                table: "VoucherItem",
                newName: "IX_VoucherItem_VoucherId");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherItems_ItemId",
                table: "VoucherItem",
                newName: "IX_VoucherItem_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherEntries_VoucherId",
                table: "VoucherEntry",
                newName: "IX_VoucherEntry_VoucherId");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherEntries_LedgerId",
                table: "VoucherEntry",
                newName: "IX_VoucherEntry_LedgerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoucherItem",
                table: "VoucherItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoucherEntry",
                table: "VoucherEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GSTTaxDetail_VoucherItem_VoucherItemId",
                table: "GSTTaxDetail",
                column: "VoucherItemId",
                principalTable: "VoucherItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherEntry_InventoryLedgers_LedgerId",
                table: "VoucherEntry",
                column: "LedgerId",
                principalTable: "InventoryLedgers",
                principalColumn: "LedgerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherEntry_Vouchers_VoucherId",
                table: "VoucherEntry",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherItem_StockItems_ItemId",
                table: "VoucherItem",
                column: "ItemId",
                principalTable: "StockItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherItem_Vouchers_VoucherId",
                table: "VoucherItem",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
