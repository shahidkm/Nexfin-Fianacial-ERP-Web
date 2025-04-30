using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class VoucherAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "StockItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "OpeningBalance",
                table: "InventoryLedgers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "InventoryLedgers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    DeliveryNoteNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DispatchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DispatchedThrough = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LRNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreightCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispatchDetails_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    LedgerId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntryType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherEntry_InventoryLedgers_LedgerId",
                        column: x => x.LedgerId,
                        principalTable: "InventoryLedgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherEntry_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherItem_StockItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StockItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherItem_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GSTTaxDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherItemId = table.Column<int>(type: "int", nullable: false),
                    CGSTPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SGSTPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IGSTPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSTTaxDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GSTTaxDetail_VoucherItem_VoucherItemId",
                        column: x => x.VoucherItemId,
                        principalTable: "VoucherItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DispatchDetails_VoucherId",
                table: "DispatchDetails",
                column: "VoucherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GSTTaxDetail_VoucherItemId",
                table: "GSTTaxDetail",
                column: "VoucherItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherEntry_LedgerId",
                table: "VoucherEntry",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherEntry_VoucherId",
                table: "VoucherEntry",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherItem_ItemId",
                table: "VoucherItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherItem_VoucherId",
                table: "VoucherItem",
                column: "VoucherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispatchDetails");

            migrationBuilder.DropTable(
                name: "GSTTaxDetail");

            migrationBuilder.DropTable(
                name: "VoucherEntry");

            migrationBuilder.DropTable(
                name: "VoucherItem");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "InventoryLedgers");

            migrationBuilder.AlterColumn<int>(
                name: "OpeningBalance",
                table: "InventoryLedgers",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
